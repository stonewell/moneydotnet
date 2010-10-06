package com.angelstone.android.dailyjournal.ui;

import java.text.MessageFormat;

import android.content.Context;
import android.database.Cursor;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.View;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.ListView;
import android.widget.ResourceCursorAdapter;
import android.widget.ResourceCursorTreeAdapter;
import android.widget.TextView;

import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.R;

public class AllJournalsView extends DailyJournalBaseView {
	private boolean mUseGroupView = false;
	private int mGroupPayDateGroupColumnIndex;
	private java.text.DateFormat mDateFormat;
	
	private class JournalAdapter extends ResourceCursorAdapter {

		public JournalAdapter(Cursor c) {
			super(AllJournalsView.this, R.layout.journal_list_item, c);
		}

		@Override
		public void bindView(View view, Context context, Cursor cursor) {
			bindJournalView(view, context, cursor);
		}
		
	}
	
	private class JournalPayDateGroupAdapter extends ResourceCursorTreeAdapter {

		public JournalPayDateGroupAdapter(Cursor cursor, Context context,
				int groupLayout, int childLayout) {
			super(context, cursor, groupLayout, childLayout);
		}

		@Override
		protected Cursor getChildrenCursor(Cursor groupCursor) {

			long begin = groupCursor.getLong(mGroupPayDateGroupColumnIndex);
			long end = begin + 86400000;

			return managedQuery(Journal.CONTENT_URI, null, Journal.COLUMN_PAY_DATE
					+ " >= ?1 AND " + Journal.COLUMN_PAY_DATE + " < ?2", new String[] {
					String.valueOf(begin), String.valueOf(end) }, Journal.COLUMN_PAY_DATE
					+ " desc");
		}

		@Override
		protected void bindChildView(View view, Context context, Cursor cursor,
				boolean isLastChild) {
			bindJournalView(view, context, cursor);
		}

		@Override
		protected void bindGroupView(View view, Context context, Cursor cursor,
				boolean isExpanded) {
			TextView tv = (TextView) view.findViewById(android.R.id.text1);

			tv.setText(mDateFormat.format(cursor
					.getLong(mGroupPayDateGroupColumnIndex)));
		}
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		// Query for people
		Cursor groupCursor = managedQuery(Journal.CONTENT_PAY_DATE_GROUP_URI, null,
				null, null, null);

		mUseGroupView = groupCursor.getCount() > 1;
		mDateFormat = DateFormat.getDateFormat(this);

		if (mUseGroupView) {
			setContentView(R.layout.all_journals_expandable);
			// Cache the ID column index
			mGroupPayDateGroupColumnIndex = groupCursor
					.getColumnIndexOrThrow(Journal.COLUMN_PAY_DATE_GROUP);

			// Set up our adapter
			ExpandableListAdapter mAdapter = new JournalPayDateGroupAdapter(
					groupCursor, this, android.R.layout.simple_expandable_list_item_1,
					R.layout.journal_list_item);

			ExpandableListView view = (ExpandableListView) findViewById(R.id.list);
			view.setAdapter(mAdapter);
		} else {
			setContentView(R.layout.all_journals_list);
			
			Cursor journalCursor = managedQuery(Journal.CONTENT_URI, null, null, null, Journal.COLUMN_PAY_DATE
					+ " desc");
			
			ListView view = (ListView)findViewById(R.id.list);
			view.setAdapter(new JournalAdapter(journalCursor));
		}

	}

	private void bindJournalView(View view, Context context, Cursor cursor) {
		TextView tv = (TextView) view.findViewById(android.R.id.text1);

		int type = cursor.getInt(cursor.getColumnIndex(Journal.COLUMN_TYPE));

		String typeStr = type == 1 ? context.getString(R.string.type_income)
				: context.getString(R.string.type_cost);

		int color = type == 1 ? android.graphics.Color.BLUE : android.graphics.Color.RED;
		
		tv.setTextAppearance(context, android.R.style.TextAppearance_Small);
		tv.setTextColor(color);
		//tv.setTextColor(ColorStateList.valueOf(color));
		
		String text = MessageFormat
				.format(
						context.getString(R.string.pay_date_group_child_template),
						new Object[] {
								cursor.getDouble(cursor.getColumnIndex(Journal.COLUMN_AMOUNT)),
								cursor.getString(cursor
										.getColumnIndex(Journal.COLUMN_PAY_METHOD)),
								cursor.getString(cursor.getColumnIndex(Journal.COLUMN_NAME)),
								cursor.getString(cursor
										.getColumnIndex(Journal.COLUMN_CATEGORY)), typeStr });

		tv.setText(text);
	}

}
