package com.angelstone.android.dailyjournal.ui;

import android.content.ContentUris;
import android.content.ContentValues;
import android.database.Cursor;
import android.net.Uri;
import android.widget.ListAdapter;

import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.R;

public abstract class UriEditableListView extends EditableListView {
	private Uri mUri;
	private String mEditColumnName;
	private String mMappedJournalColumnName;

	public UriEditableListView(Uri uri, String editColumnName,
			String mappedJournalTableColumnName) {
		mUri = uri;
		mEditColumnName = editColumnName;
		mMappedJournalColumnName = mappedJournalTableColumnName;
	}

	@Override
	protected String getEditText(long childId) {
		Uri uri = ContentUris.appendId(mUri.buildUpon(), childId).build();

		Cursor c = null;

		try {
			c = getContentResolver().query(uri, null, null, null, null);

			if (c.moveToFirst()) {
				String entry = c.getString(c.getColumnIndex(mEditColumnName));

				return entry;
			}
		} finally {
			if (c != null)
				c.close();
		}

		return "";
	}

	@Override
	protected String getConfirmMessage(long childId) {
		if (childId < 0)
			return getString(R.string.confirm_delete_all_entry);
		
		Uri uri = ContentUris.appendId(mUri.buildUpon(), childId).build();

		Cursor c = null;
		Cursor c1 = null;
		int resId = R.string.confirm_delete_selected_entry;

		try {
			c = getContentResolver().query(uri, null, null, null, null);

			if (c.moveToFirst()) {
				String entry = c.getString(c.getColumnIndex(mEditColumnName));

				c1 = getContentResolver().query(Journal.CONTENT_URI,
						new String[] { Journal.COLUMN_ID },
						mMappedJournalColumnName + "=?1",
						new String[] { entry }, null);

				if (c1.getCount() > 0)
					resId = R.string.confirm_delete_used_entry;
			}
		} finally {
			if (c != null)
				c.close();

			if (c1 != null)
				c1.close();
		}

		return getString(resId);
	}

	@Override
	protected ListAdapter createListAdapter() {
		Cursor c = managedQuery(mUri, null, null, null, null);
		return new NameCursorAdapter(this, android.R.layout.simple_list_item_1,
				c);
	}

	@Override
	protected void doDeleteEntry(long childId) {
		Uri uri = ContentUris.appendId(mUri.buildUpon(), childId).build();

		getContentResolver().delete(uri, null, null);
	}

	@Override
	protected void doUpdateEntry(long childId, String entry) {
		ContentValues values = new ContentValues();

		values.put(mEditColumnName, entry);

		Uri uri = ContentUris.appendId(mUri.buildUpon(), childId).build();

		getContentResolver().update(uri, values, null, null);
	}

	@Override
	protected void doNewEntry(String text) {
		Cursor c = null;

		try {
			c = getContentResolver().query(mUri, null, mEditColumnName + "=?1",
					new String[] { text }, null);

			if (c.getCount() > 0) {
				return;
			}
			
			ContentValues values = new ContentValues();
			values.put(mEditColumnName, text);
			
			getContentResolver().insert(mUri, values);
		} finally {
			if (c != null)
				c.close();
		}
	}

	@Override
	protected void doDeleteAllEntry() {
		getContentResolver().delete(mUri, null, null);
	}

}
