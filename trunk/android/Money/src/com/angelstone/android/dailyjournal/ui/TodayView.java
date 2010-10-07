package com.angelstone.android.dailyjournal.ui;

import java.text.MessageFormat;
import java.text.NumberFormat;
import java.util.Calendar;

import org.json.JSONArray;
import org.json.JSONObject;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.text.format.DateFormat;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ResourceCursorAdapter;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;
import android.widget.ToggleButton;

import com.angelstone.android.dailyjournal.Category;
import com.angelstone.android.dailyjournal.Constants;
import com.angelstone.android.dailyjournal.DatabaseInitializer;
import com.angelstone.android.dailyjournal.DatabaseManager;
import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.PayMethod;
import com.angelstone.android.dailyjournal.R;
import com.angelstone.android.utils.ActivityLog;
import com.angelstone.android.utils.HttpUtils;

public class TodayView extends DailyJournalBaseView implements OnClickListener,
		OnItemSelectedListener, OnFocusChangeListener {

	private static final int DATE_DIALOG_ID = 1;
	private static final int INIT_DATA_PROGRESS_DIALOG_ID = 2;
	private static final int UPLOAD_PROGRESS_DIALOG_ID = 3;

	private static final int[][] OPTION_MENUS = new int[][] {
			new int[] { R.string.add_journal, android.R.drawable.ic_menu_save },
			new int[] { R.string.upload, android.R.drawable.ic_menu_upload },
			new int[] { R.string.view_records, android.R.drawable.ic_menu_view }, };

	private Calendar mToday = Calendar.getInstance();

	private Cursor mCategoryCursor = null;
	private Cursor mPaymethodCursor = null;
	private Cursor mNameCursor = null;

	private ProgressDialog mProgressDialog;
	private Handler mProgressHandler;

	private int mProgress;
	private int mMaxProgress;

	private long mJournalId = -1;

	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener() {

		public void onDateSet(DatePicker view, int year, int monthOfYear,
				int dayOfMonth) {
			mToday.set(year, monthOfYear, dayOfMonth);
			updateDisplay();
		}
	};

	private class NameCursorAdapter extends ResourceCursorAdapter {
		private int mNameIndex = -1;

		public NameCursorAdapter(Context context, int layout, Cursor c) {
			super(context, layout, c, true);

			for (int i = 0; i < c.getColumnCount(); i++)
				Log.e(Constants.TAG, i + "=" + c.getColumnName(i));

			mNameIndex = c.getColumnIndex(Constants.COLUMN_NAME);
		}

		@Override
		public void bindView(View view, Context context, Cursor cursor) {
			if (view instanceof TextView) {
				TextView tv = (TextView) view;
				tv.setText(cursor.getString(mNameIndex));
			}
		}

		@Override
		public boolean hasStableIds() {
			return true;
		}

	};

	public TodayView() {
		super(OPTION_MENUS.length);
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.today_table);

		mToday = Calendar.getInstance();

		initData();

		Button btnPick = (Button) findViewById(R.id.pickDate);
		btnPick.setOnClickListener(this);

		prepareCursors();

		Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);
		NameCursorAdapter adapter = new NameCursorAdapter(this,
				android.R.layout.simple_spinner_item, mCategoryCursor);
		adapter
				.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinCategory.setAdapter(adapter);
		if (adapter.getCount() > 0) {
			spinCategory.setSelection(0);
		}

		Spinner spinPaymethod = (Spinner) findViewById(R.id.spinner_paymethod);
		adapter = new NameCursorAdapter(this, android.R.layout.simple_spinner_item,
				mPaymethodCursor);
		adapter
				.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinPaymethod.setAdapter(adapter);
		if (adapter.getCount() > 0) {
			spinPaymethod.setSelection(0);
		}

		Spinner spinName = (Spinner) findViewById(R.id.spinner_name);
		adapter = new NameCursorAdapter(this, android.R.layout.simple_spinner_item,
				mNameCursor);
		adapter
				.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinName.setAdapter(adapter);
		spinName.setOnItemSelectedListener(this);
		if (adapter.getCount() > 0) {
			spinName.setSelection(0);
		}

		EditText etName = (EditText) findViewById(R.id.edit_name);
		etName.setOnFocusChangeListener(this);

		if (getIntent() != null) {
			updateDisplayByIntent(getIntent());
		}

		updateDisplay();
	}

	private void updateDisplayByIntent(Intent intent) {
		String action = intent.getAction();

		if (!Constants.ACTION_EDIT_JOURNAL.equals(action))
			return;

		mJournalId = intent.getLongExtra(Constants.COLUMN_ID, -1);

		if (mJournalId < 0)
			return;

		Cursor c = null;
		try {
			Uri uri = ContentUris.appendId(Journal.CONTENT_URI.buildUpon(),
					mJournalId).build();
			c = getContentResolver().query(uri, null, null, null, null);

			if (!c.moveToFirst())
				return;

			mToday.setTimeInMillis(c.getLong(c
					.getColumnIndex(Journal.COLUMN_PAY_DATE)));

			selectCategory(c.getString(c.getColumnIndex(Journal.COLUMN_CATEGORY)));
			selectPayMethod(c.getString(c.getColumnIndex(Journal.COLUMN_PAY_METHOD)));

			EditText etAmount = (EditText) findViewById(R.id.edit_amount);
			etAmount.setText(String.valueOf(c.getDouble(c
					.getColumnIndex(Journal.COLUMN_AMOUNT))));

			ToggleButton tbType = (ToggleButton) findViewById(R.id.toggle_type);
			tbType.setChecked(c.getInt(c.getColumnIndex(Journal.COLUMN_TYPE)) == 1);

			EditText etName = (EditText) findViewById(R.id.edit_name);
			etName.setText(c.getString(c.getColumnIndex(Journal.COLUMN_NAME)));

			EditText etDesc = (EditText) findViewById(R.id.edit_description);
			etDesc.setText(c.getString(c.getColumnIndex(Journal.COLUMN_DESCRIPTION)));
		} finally {
			if (c != null)
				c.close();
		}
	}

	private void selectPayMethod(String payMethod) {
		Spinner spinPaymethod = (Spinner) findViewById(R.id.spinner_paymethod);

		selectSpinnerByName(spinPaymethod, payMethod);
	}

	private void selectCategory(String category) {
		Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);

		selectSpinnerByName(spinCategory, category);
	}

	private void selectSpinnerByName(Spinner spinner, String name) {
		int count = spinner.getCount();
		SpinnerAdapter adapter = spinner.getAdapter();
		int idx = -1;

		for (int i = 0; i < count; i++) {
			Cursor c = (Cursor) adapter.getItem(i);

			if (idx < 0)
				idx = c.getColumnIndex(Category.COLUMN_NAME);

			if (name.equals(c.getString(idx))) {
				spinner.setSelection(i);
				return;
			}
		}
	}

	private void initData() {
		boolean dataInited = DatabaseManager.readSetting(this,
				Constants.OPTION_DATA_INIT);

		if (dataInited)
			return;

		final DatabaseInitializer init = new DatabaseInitializer();
		mMaxProgress = init.getEntryCount();

		showDialog(INIT_DATA_PROGRESS_DIALOG_ID);

		mProgress = 0;
		mProgressDialog.setProgress(0);

		mProgressHandler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				if (mProgress >= mMaxProgress) {
					mProgressDialog.dismiss();
					DatabaseManager.writeSetting(TodayView.this,
							Constants.OPTION_DATA_INIT, true);
				} else {
					try {
						mProgress++;
						mProgressDialog.incrementProgressBy(1);
						init.processEntry(TodayView.this, mProgress - 1);
					} catch (Exception ex) {
						mProgressDialog.setMessage(ex.getLocalizedMessage());
					}
					mProgressHandler.sendEmptyMessage(0);
				}
			}
		};

		mProgressHandler.sendEmptyMessage(0);
	}

	private void prepareCursors() {
		mCategoryCursor = managedQuery(Category.CONTENT_ORDER_COUNT_URI, null,
				null, null, null);
		mPaymethodCursor = managedQuery(PayMethod.CONTENT_ORDER_COUNT_URI, null,
				null, null, null);
		mNameCursor = managedQuery(Journal.CONTENT_NAME_URI, null, null, null, null);
	}

	private void updateDisplay() {
		TextView date = (TextView) findViewById(R.id.dateDisplay);
		java.text.DateFormat df = DateFormat.getDateFormat(this);
		date.setText(df.format(mToday.getTime()));

		updateTodayTotal();
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.pickDate:
			showDialog(DATE_DIALOG_ID);
			break;
		}

	}

	@Override
	protected Dialog onCreateDialog(int id) {
		switch (id) {
		case DATE_DIALOG_ID:
			return new DatePickerDialog(this, mDateSetListener,
					mToday.get(Calendar.YEAR), mToday.get(Calendar.MONTH),
					mToday.get(Calendar.DATE));
		case INIT_DATA_PROGRESS_DIALOG_ID:
			mProgressDialog = new ProgressDialog(this);
			mProgressDialog.setIcon(android.R.drawable.ic_dialog_info);
			mProgressDialog.setTitle(R.string.initial_data);
			mProgressDialog.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
			mProgressDialog.setMax(mMaxProgress);
			mProgressDialog.setCancelable(false);
			return mProgressDialog;
		case UPLOAD_PROGRESS_DIALOG_ID:
			mProgressDialog = new ProgressDialog(this);
			mProgressDialog.setIcon(android.R.drawable.ic_dialog_info);
			mProgressDialog.setTitle(R.string.upload);
			mProgressDialog.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
			mProgressDialog.setMax(mMaxProgress);
			mProgressDialog.setCancelable(false);
			return mProgressDialog;
		}
		return null;
	}

	@Override
	protected void onPrepareDialog(int id, Dialog dialog) {
		switch (id) {
		case DATE_DIALOG_ID:
			((DatePickerDialog) dialog).updateDate(mToday.get(Calendar.YEAR),
					mToday.get(Calendar.MONTH), mToday.get(Calendar.DATE));

			break;
		}
	}

	@Override
	public boolean onPrepareOptionsMenu(Menu menu) {
		menu.clear();

		createMenus(menu, 0, OPTION_MENUS);

		return super.onPrepareOptionsMenu(menu);
	}

	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case 0: {
			saveJournal();
			break;
		}
		case 1: {
			uploadJournals();
			break;
		}
		case 2: {
			Intent intent = new Intent();
			intent.setClass(this, AllJournalsView.class);
			startActivity(intent);
			break;
		}
		default:
			return super.onOptionsItemSelected(item);
		}
		return true;
	}

	private void saveJournal() {
		if (!validateInput()) {
			return;
		}

		ContentValues values = new ContentValues();
		Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);
		Spinner spinPaymethod = (Spinner) findViewById(R.id.spinner_paymethod);

		Cursor c = (Cursor) spinCategory.getSelectedItem();
		int idx = c.getColumnIndex(Constants.COLUMN_NAME);
		values.put(Journal.COLUMN_CATEGORY, c.getString(idx));

		EditText etAmount = (EditText) findViewById(R.id.edit_amount);
		values.put(Journal.COLUMN_AMOUNT,
				Double.parseDouble(etAmount.getText().toString().trim()));

		values.put(Journal.COLUMN_CREATE_DATE, Calendar.getInstance()
				.getTimeInMillis());

		values.put(Journal.COLUMN_PAY_DATE, mToday.getTimeInMillis());
		values.put(Journal.COLUMN_SYNC, Constants.SYNC_NONE);

		c = (Cursor) spinPaymethod.getSelectedItem();
		idx = c.getColumnIndex(Constants.COLUMN_NAME);
		values.put(Journal.COLUMN_PAY_METHOD, c.getString(idx));

		ToggleButton tbType = (ToggleButton) findViewById(R.id.toggle_type);
		values.put(Journal.COLUMN_TYPE, tbType.isChecked() ? (int) 1 : (int) 0);

		EditText etName = (EditText) findViewById(R.id.edit_name);
		values.put(Journal.COLUMN_NAME, etName.getText().toString().trim());

		EditText etDesc = (EditText) findViewById(R.id.edit_description);
		values.put(Journal.COLUMN_DESCRIPTION, etDesc.getText().toString());

		if (mJournalId < 0) {
			values.put(Journal.COLUMN_UID, DatabaseManager.generateUid());
			getContentResolver().insert(Journal.CONTENT_URI, values);
		} else {
			Uri uri = ContentUris.appendId(Journal.CONTENT_URI.buildUpon(),
					mJournalId).build();

			getContentResolver().update(uri, values, null, null);
		}

		mNameCursor.requery();
		etAmount.setText("");

		showToast(R.string.journal_added);
		updateTodayTotal();
	}

	private boolean validateInput() {
		EditText etName = (EditText) findViewById(R.id.edit_name);
		EditText etAmount = (EditText) findViewById(R.id.edit_amount);

		if (TextUtils.isEmpty(etName.getText().toString().trim())) {
			showToast(R.string.name_is_empty);
			return false;
		}

		String amountStr = etAmount.getText().toString().trim();
		if (TextUtils.isEmpty(amountStr)) {
			showToast(R.string.amount_is_empty);
			return false;
		}

		if (Double.parseDouble(amountStr) <= 0) {
			showToast(R.string.amount_must_great_than_zero);
			return false;
		}
		return true;
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position,
			long id) {
		switch (parent.getId()) {
		case R.id.spinner_name: {
			EditText etName = (EditText) findViewById(R.id.edit_name);
			Cursor c = (Cursor) parent.getItemAtPosition(position);
			etName.setText(c.getString(c.getColumnIndex(Journal.COLUMN_NAME)));
			selectMostPopularCategoryForName();
			break;
		}
		default:
			break;
		}

	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {

	}

	@Override
	public void onFocusChange(View v, boolean hasFocus) {
		switch (v.getId()) {
		case R.id.edit_name: {
			if (!hasFocus) {
				selectMostPopularCategoryForName();
			}
			break;
		}
		default:
			break;
		}

	}

	private void selectMostPopularCategoryForName() {
		EditText etName = (EditText) findViewById(R.id.edit_name);
		String name = etName.getText().toString().trim();

		if (TextUtils.isEmpty(name))
			return;

		Cursor c = null, c1 = null;

		try {
			c = getContentResolver().query(Journal.CONTENT_NAME_CATEGORY_URI, null,
					Journal.COLUMN_NAME + "=?1", new String[] { name }, "count desc");

			if (!c.moveToFirst())
				return;

			String category = c.getString(c.getColumnIndex(Journal.COLUMN_CATEGORY));

			Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);

			c1 = getContentResolver().query(Category.CONTENT_URI,
					new String[] { Category.COLUMN_ID }, Category.COLUMN_NAME + "=?1",
					new String[] { category }, null);

			if (!c1.moveToFirst())
				return;

			int id = c1.getInt(0);

			for (int i = 0; i < spinCategory.getCount(); i++) {
				if (id == spinCategory.getItemIdAtPosition(i)) {
					spinCategory.setSelection(i);
					break;
				}
			}
		} finally {
			if (c != null)
				c.close();
			if (c1 != null)
				c1.close();
		}
	}

	private void updateTodayTotal() {
		Cursor c = null;
		double cost = 0;
		double income = 0;

		try {
			Calendar zero = Calendar.getInstance();
			zero.setTimeInMillis(mToday.getTimeInMillis());
			zero.set(Calendar.HOUR_OF_DAY, 0);
			zero.set(Calendar.MINUTE, 0);
			zero.set(Calendar.SECOND, 0);

			Calendar end = Calendar.getInstance();
			end.setTimeInMillis(mToday.getTimeInMillis());
			end.set(Calendar.HOUR_OF_DAY, 23);
			end.set(Calendar.MINUTE, 59);
			end.set(Calendar.SECOND, 59);

			c = getContentResolver().query(
					Journal.CONTENT_URI,
					new String[] { Journal.COLUMN_AMOUNT, Journal.COLUMN_TYPE },
					Journal.COLUMN_PAY_DATE + " >= ?1 AND " + Journal.COLUMN_PAY_DATE
							+ " <= ?2",
					new String[] { String.valueOf(zero.getTimeInMillis()),
							String.valueOf(end.getTimeInMillis()) }, null);

			int idxType = c.getColumnIndex(Journal.COLUMN_TYPE);
			int idxAmount = c.getColumnIndex(Journal.COLUMN_AMOUNT);

			while (c.moveToNext()) {
				if (c.getInt(idxType) == 0) {
					cost += c.getDouble(idxAmount);
				} else {
					income += c.getDouble(idxAmount);
				}
			}
		} finally {
			if (c != null)
				c.close();
		}

		NumberFormat nf = NumberFormat.getCurrencyInstance();

		TextView etIncome = (TextView) findViewById(R.id.edit_income_today);
		TextView etCost = (TextView) findViewById(R.id.edit_cost_today);

		etIncome.setText(nf.format(income));
		etCost.setText(nf.format(cost));
	}

	private void uploadJournals() {
		final Cursor c = getContentResolver().query(Journal.CONTENT_URI, null,
				Journal.COLUMN_SYNC + "=?1",
				new String[] { String.valueOf(Constants.SYNC_NONE) }, null);

		if (c.getCount() == 0) {
			c.close();
			return;
		}

		mMaxProgress = 2;

		showDialog(UPLOAD_PROGRESS_DIALOG_ID);

		mProgress = 0;
		mProgressDialog.setProgress(0);

		mProgressHandler = new Handler() {
			private String mUploadData = null;

			@Override
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				try {
					if (mProgress >= mMaxProgress) {
						mProgressDialog.dismiss();
						DatabaseManager.writeSetting(TodayView.this,
								Constants.OPTION_DATA_INIT, true);
						if (c != null)
							c.close();
					} else if (mProgress == 0) {
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

						do {
							value = new JSONObject();
							value.put(Journal.COLUMN_AMOUNT, c.getDouble(idxAmount));
							value.put(Journal.COLUMN_NAME, c.getString(idxName));
							value.put(Journal.COLUMN_TYPE, c.getInt(idxType));
							value.put(Journal.COLUMN_CATEGORY, c.getString(idxCategory));
							value.put(Journal.COLUMN_PAY_METHOD, c.getString(idxPayMethod));
							value.put(Journal.COLUMN_PAY_DATE, c.getLong(idxPayDate));
							value.put(Journal.COLUMN_CREATE_DATE, c.getLong(idxCreateDate));
							value
									.put(Journal.COLUMN_DESCRIPTION, c.getString(idxDescription));
							value.put(Journal.COLUMN_UID, c.getString(idxUid));

							array.put(index++, value);
						} while (c.moveToNext());

						mUploadData = array.toString();

						mProgress++;
						mProgressDialog.incrementProgressBy(1);
						mProgressHandler.sendEmptyMessage(0);
					} else {
						String url = "http://accountdiary.appspot.com/entry/batchAdd";
						String response = HttpUtils.postData(TodayView.this, url,
								Constants.PARAM_ENTRIES, mUploadData);

						mProgress++;
						mProgressDialog.incrementProgressBy(1);

						if ("1".equals(response)) {
							ActivityLog.logInfo(TodayView.this, getString(R.string.app_name),
									getString(R.string.upload_success));
						} else {
							throw new Exception(response);
						}

						ContentValues values = new ContentValues();
						values.put(Journal.COLUMN_SYNC, Constants.SYNC_DONE);

						getContentResolver().update(Journal.CONTENT_URI, values,
								Journal.COLUMN_SYNC + "=" + Constants.SYNC_NONE, null);

						mProgressHandler.sendEmptyMessage(0);
					}
				} catch (Exception ex) {
					Log.e(getString(R.string.app_name), "Upload Error", ex);
					mProgress = mMaxProgress;
					mProgressDialog.setIcon(android.R.drawable.ic_dialog_alert);

					String logMsg = MessageFormat.format(getString(R.string.upload_fail),
							ex.getLocalizedMessage());

					mProgressDialog.setMessage(logMsg);
					ActivityLog.logError(TodayView.this, getString(R.string.app_name),
							logMsg);
					mProgressHandler.sendEmptyMessageDelayed(0, 1000);
				}
			}
		};

		mProgressHandler.sendEmptyMessage(0);
	}

	@Override
	protected void onResume() {
		super.onResume();
		updateDisplay();
	}
}