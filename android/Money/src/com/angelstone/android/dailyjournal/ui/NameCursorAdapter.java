package com.angelstone.android.dailyjournal.ui;

import android.content.Context;
import android.database.Cursor;
import android.view.View;
import android.widget.ResourceCursorAdapter;
import android.widget.TextView;

import com.angelstone.android.dailyjournal.Constants;

public class NameCursorAdapter extends ResourceCursorAdapter {
	private int mNameIndex = -1;

	public NameCursorAdapter(Context context, int layout, Cursor c) {
		super(context, layout, c, true);

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
