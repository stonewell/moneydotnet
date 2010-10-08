package com.angelstone.android.dailyjournal;

import android.content.ContentValues;
import android.content.Context;
import android.net.Uri;

public class DatabaseInitializer {
	private Object[][] entries;

	private Context mContext;

	public DatabaseInitializer(Context context) {
		mContext = context;

		loadData();
	}

	private void loadData() {
		String[] categories = mContext.getResources().getStringArray(
				R.array.categories);
		String[] paymethods = mContext.getResources().getStringArray(
				R.array.paymethods);
		entries = new Object[categories.length + paymethods.length][];

		for (int i = 0; i < categories.length; i++) {
			entries[i] = new Object[3];
			entries[i][0] = Category.CONTENT_URI;
			entries[i][1] = Category.COLUMN_NAME;
			entries[i][2] = categories[i];
		}

		for (int i = 0; i < paymethods.length; i++) {
			entries[i + categories.length] = new Object[3];
			entries[i + categories.length][0] = PayMethod.CONTENT_URI;
			entries[i + categories.length][1] = PayMethod.COLUMN_NAME;
			entries[i + categories.length][2] = paymethods[i];
		}
	}

	public int getEntryCount() {
		return entries.length;
	}

	public void processEntry(int entry) {
		if (entry < 0 || entry >= entries.length)
			return;

		Object[] v = entries[entry];

		Uri uri = (Uri) v[0];
		ContentValues values = new ContentValues();

		for (int i = 1; i < v.length; i += 2) {
			values.put((String) v[i], (String) v[i + 1]);
		}

		mContext.getContentResolver().insert(uri, values);
	}

	public void clearData() {
		mContext.getContentResolver().delete(PayMethod.CONTENT_URI, null, null);
		mContext.getContentResolver().delete(Category.CONTENT_URI, null, null);
	}
}
