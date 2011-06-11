package com.angelstone.android.dailyjournal.service;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.net.InetSocketAddress;
import java.net.MalformedURLException;
import java.net.Proxy;
import java.net.URL;
import java.net.UnknownHostException;
import java.text.MessageFormat;
import java.util.Hashtable;
import java.util.zip.GZIPOutputStream;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.IntentService;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.os.PowerManager;
import android.os.PowerManager.WakeLock;
import android.util.Log;

import com.angelstone.android.dailyjournal.Constants;
import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.R;
import com.angelstone.android.dailyjournal.ui.TodayView;
import com.angelstone.android.utils.ActivityLog;
import com.angelstone.android.utils.HttpUtils;

public class UploadDataService extends IntentService {

	public UploadDataService() {
		super("DailyJournal_UploadData_Service");
	}

	@Override
	protected void onHandleIntent(Intent intent) {
		PowerManager pm = (PowerManager) getSystemService(Context.POWER_SERVICE);

		WakeLock wl = null;

		Cursor c = null;

		try {
			wl = pm.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK,
					getString(R.string.app_name));
			wl.setReferenceCounted(false);
			wl.acquire();

			c = getContentResolver().query(Journal.CONTENT_URI, null,
					Journal.COLUMN_SYNC + "=?1",
					new String[] { String.valueOf(Constants.SYNC_NONE) }, null);

			if (c == null || c.getCount() == 0)
				return;

			notifyUpload(this, getString(R.string.upload_begin), false);

			c.moveToFirst();

			JSONArray array = new JSONArray();
			int index = 0;
			JSONObject value = null;

			int idxAmount = c.getColumnIndex(Journal.COLUMN_AMOUNT);
			int idxName = c.getColumnIndex(Journal.COLUMN_NAME);
			int idxType = c.getColumnIndex(Journal.COLUMN_TYPE);
			int idxCategory = c.getColumnIndex(Journal.COLUMN_CATEGORY);
			int idxPayMethod = c.getColumnIndex(Journal.COLUMN_PAY_METHOD);
			int idxPayDate = c.getColumnIndex(Journal.COLUMN_PAY_DATE);
			int idxCreateDate = c.getColumnIndex(Journal.COLUMN_CREATE_DATE);
			int idxDescription = c.getColumnIndex(Journal.COLUMN_DESCRIPTION);
			int idxUid = c.getColumnIndex(Journal.COLUMN_UID);
			int idxDeleted = c.getColumnIndex(Journal.COLUMN_DELETED);

			do {
				value = new JSONObject();
				value.put(Journal.COLUMN_AMOUNT, c.getDouble(idxAmount));
				value.put(Journal.COLUMN_NAME, c.getString(idxName));
				value.put(Journal.COLUMN_TYPE, c.getInt(idxType));
				value.put(Journal.COLUMN_CATEGORY, c.getString(idxCategory));
				value.put(Journal.COLUMN_PAY_METHOD, c.getString(idxPayMethod));
				value.put(Journal.COLUMN_PAY_DATE, c.getLong(idxPayDate));
				value.put(Journal.COLUMN_CREATE_DATE, c.getLong(idxCreateDate));
				value.put(Journal.COLUMN_DESCRIPTION,
						c.getString(idxDescription));
				value.put(Journal.COLUMN_UID, c.getString(idxUid));
				value.put(Journal.COLUMN_DELETED, c.getInt(idxDeleted));

				array.put(index++, value);
			} while (c.moveToNext());

			String url = getUploadUrl(this);
			int timeout = getTimeout(this);
			
			String response = HttpUtils.postData(url,
					getGZipByteArray(array.toString()),
					createProxyFromPreference(this, url), timeout);

			if ("1".equals(response)) {
				ActivityLog.logInfo(this, getString(R.string.app_name),
						getString(R.string.upload_success));
			} else {
				throw new Exception(response);
			}

			ContentValues values = new ContentValues();
			values.put(Journal.COLUMN_SYNC, Constants.SYNC_DONE);

			getContentResolver().update(Journal.CONTENT_URI, values,
					Journal.COLUMN_SYNC + "=" + Constants.SYNC_NONE, null);

			getContentResolver().delete(Journal.CONTENT_URI,
					Journal.COLUMN_DELETED + "= 1", null);

			notifyUpload(this, getString(R.string.upload_success), true);
		} catch (Exception ex) {
			Log.e(getString(R.string.app_name), "Upload Error", ex);

			String logMsg = MessageFormat.format(
					getString(R.string.upload_fail), ex.getLocalizedMessage());

			ActivityLog.logError(this, getString(R.string.app_name), logMsg);
			notifyUpload(this, logMsg, true);
		} finally {
			if (wl != null)
				wl.release();

			if (c != null)
				c.close();
		}

	}

	private static String getUploadUrl(Context context) {
		SharedPreferences perf = context.getSharedPreferences(
				context.getPackageName() + "_preferences", 0);

		return perf.getString("upload_url",
				"http://accountdiary.appspot.com/entry/batchAdd");
	}

	private static int getTimeout(Context context) {
		SharedPreferences perf = context.getSharedPreferences(
				context.getPackageName() + "_preferences", 0);

		return Integer.parseInt(perf.getString("upload_timeout",
				"90"));
	}

	private static byte[] getGZipByteArray(String data) throws IOException {
		ByteArrayOutputStream bos = new ByteArrayOutputStream(8192);
		GZIPOutputStream gos = new GZIPOutputStream(bos);

		gos.write(data.getBytes("UTF-8"));
		gos.flush();
		gos.close();
		return bos.toByteArray();
	}

	private static void notifyUpload(Context context, String msg, boolean isdone) {
		// title resource id
		int titleResId;
		// the text in the notification's line 1 and 2.
		String expandedText;

		NotificationManager mNotificationMgr = (NotificationManager) context
				.getSystemService(Context.NOTIFICATION_SERVICE);

		titleResId = R.string.upload;
		expandedText = msg;

		// create the target call log intent
		final PendingIntent intent = getNotificationIntent(context);

		Notification notification = new Notification(
				isdone ? android.R.drawable.stat_notify_sync_noanim
						: android.R.drawable.stat_notify_sync, // icon
				isdone ? msg : context.getString(R.string.upload_begin), // tickerText
				System.currentTimeMillis());

		notification.setLatestEventInfo(context, context.getText(titleResId),
				expandedText, intent);

		// make the notification
		mNotificationMgr.notify(Constants.NOTIFY_UPLOAD_DONE, notification);
	}

	private static PendingIntent getNotificationIntent(Context context) {
		Intent intent = new Intent(context, TodayView.class);
		intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
		intent.putExtra("NOTIFY", true);

		return PendingIntent.getActivity(context.getApplicationContext(), 0,
				intent, PendingIntent.FLAG_UPDATE_CURRENT);
	}

	private static Object createProxyFromPreference(Context context, String urlString)
			throws UnknownHostException, MalformedURLException {
		SharedPreferences perf = context.getSharedPreferences(
				context.getPackageName() + "_preferences", 0);

		if (!perf.getBoolean("proxy_enable", false))
			return null;

		String[] proxy_types = context.getResources().getStringArray(
				R.array.proxytypes);

		String proxy_type = perf.getString("proxy_type", proxy_types[0]);
		String proxy_host = perf.getString("proxy_host", null);
		String proxy_port = perf.getString("proxy_port", null);

		if (proxy_host == null || proxy_port == null)
			return null;

		if (proxy_types[0].equals(proxy_type)) {
			Hashtable<String, Object[]> results = new Hashtable<String, Object[]>();
			
			URL url = new URL(urlString);
			
			String key = url.getHost();
			
			if (url.getPort() != -1)
				key += "_" + url.getPort();
			else
				key += "_80";
			
			results.put(key, new Object[] {proxy_host, proxy_port});
			
			return results;
		}
		
		try {
			return new Proxy(Proxy.Type.valueOf(proxy_type),
					new InetSocketAddress(proxy_host,
							Integer.parseInt(proxy_port)));
		} catch (Throwable t) {
			ActivityLog.logError(context, context.getString(R.string.app_name),
					t.getMessage());

			return null;
		}
	}
}
