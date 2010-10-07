package com.angelstone.android.dailyjournal.ui;

import java.text.MessageFormat;

import android.app.AlertDialog;
import android.content.ContentUris;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.ExpandableListContextMenuInfo;
import android.widget.ListView;
import android.widget.ResourceCursorAdapter;
import android.widget.ResourceCursorTreeAdapter;
import android.widget.TextView;

import com.angelstone.android.dailyjournal.Constants;
import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.R;

public class AllJournalsView extends DailyJournalBaseView {
	private boolean mUseGroupView = false;
	private int mGroupPayDateGroupColumnIndex;
	private java.text.DateFormat mDateFormat;
	private ExpandableListAdapter mExpandableAdapter;
	private JournalAdapter mJournalAdapter;
	private Cursor mGroupCursor;

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
		mGroupCursor = managedQuery(Journal.CONTENT_PAY_DATE_GROUP_URI, null, null,
				null, null);

		mUseGroupView = mGroupCursor.getCount() > 1;
		mDateFormat = DateFormat.getDateFormat(this);

		if (mUseGroupView) {
			setContentView(R.layout.all_journals_expandable);
			// Cache the ID column index
			mGroupPayDateGroupColumnIndex = mGroupCursor
					.getColumnIndexOrThrow(Journal.COLUMN_PAY_DATE_GROUP);

			// Set up our adapter
			mExpandableAdapter = new JournalPayDateGroupAdapter(mGroupCursor, this,
					android.R.layout.simple_expandable_list_item_1,
					R.layout.journal_list_item);

			ExpandableListView view = (ExpandableListView) findViewById(R.id.list);
			view.setAdapter(mExpandableAdapter);
			registerForContextMenu(view);
		} else {
			setContentView(R.layout.all_journals_list);

			Cursor journalCursor = managedQuery(Journal.CONTENT_URI, null, null,
					null, Journal.COLUMN_PAY_DATE + " desc");

			ListView view = (ListView) findViewById(R.id.list);

			mJournalAdapter = new JournalAdapter(journalCursor);
			view.setAdapter(mJournalAdapter);
			registerForContextMenu(view);
		}

	}

	private void bindJournalView(View view, Context context, Cursor cursor) {
		TextView tv = (TextView) view.findViewById(android.R.id.text1);

		int type = cursor.getInt(cursor.getColumnIndex(Journal.COLUMN_TYPE));

		String typeStr = type == 1 ? context.getString(R.string.type_income)
				: context.getString(R.string.type_cost);

		int color = type == 1 ? android.graphics.Color.BLUE
				: android.graphics.Color.RED;

		tv.setTextAppearance(context, android.R.style.TextAppearance_Small);
		tv.setTextColor(color);
		// tv.setTextColor(ColorStateList.valueOf(color));

		String text = MessageFormat.format(
				context.getString(R.string.pay_date_group_child_template),
				new Object[] {
						cursor.getDouble(cursor.getColumnIndex(Journal.COLUMN_AMOUNT)),
						cursor.getString(cursor.getColumnIndex(Journal.COLUMN_PAY_METHOD)),
						cursor.getString(cursor.getColumnIndex(Journal.COLUMN_NAME)),
						cursor.getString(cursor.getColumnIndex(Journal.COLUMN_CATEGORY)),
						typeStr });

		tv.setText(text);
	}

	public void onCreateContextMenu(ContextMenu menu, View v,
			ContextMenuInfo menuInfo) {

		boolean clickOnGroup = false;

		if (menuInfo instanceof ExpandableListContextMenuInfo) {
			ExpandableListContextMenuInfo info = (ExpandableListContextMenuInfo) menuInfo;

			clickOnGroup = ExpandableListView
					.getPackedPositionType(info.packedPosition) == ExpandableListView.PACKED_POSITION_TYPE_GROUP;
		}

		if (!clickOnGroup)
			menu.add(0, 1, 1, R.string.menu_edit);
		menu.add(0, 2, 2, R.string.menu_delete);

		super.onCreateContextMenu(menu, v, menuInfo);

	}

	public boolean onContextItemSelected(MenuItem item) {
		ContextMenuInfo menuInfo = item.getMenuInfo();
		boolean clickOnGroup = false;
		int groupPos = 0;
		long childId = 0;

		if (menuInfo instanceof ExpandableListContextMenuInfo) {
			ExpandableListContextMenuInfo info = (ExpandableListContextMenuInfo) menuInfo;

			clickOnGroup = ExpandableListView
					.getPackedPositionType(info.packedPosition) == ExpandableListView.PACKED_POSITION_TYPE_GROUP;

			groupPos = ExpandableListView.getPackedPositionGroup(info.packedPosition);

			if (!clickOnGroup) {
				childId = info.id;
			}
		} else if (menuInfo instanceof AdapterContextMenuInfo) {
			AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
			childId = info.id;
			clickOnGroup = false;
		} else {
			return false;
		}

		switch (item.getItemId()) {
		case 1: {
			editJournal(childId);
			break;
		}
		case 2: {
			if (clickOnGroup)
				deleteGroupJournal(groupPos);
			else
				deleteJournal(childId);
			break;

		}
		default:
			return super.onContextItemSelected(item);
		}

		return true;
	}

	private void editJournal(long childId) {
		Intent intent = new Intent(this, TodayView.class);
		intent.setAction(Constants.ACTION_EDIT_JOURNAL);
		intent.putExtra(Journal.COLUMN_ID, childId);
		
		startActivity(intent);
	}

	private void deleteJournal(final long childId) {
		AlertDialog ad = new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_alert)
				.setTitle(android.R.string.dialog_alert_title)
				.setMessage(R.string.confirm_delete_selected_journal)
				.setPositiveButton(android.R.string.yes,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog, int whichButton) {
								Uri uri = ContentUris.appendId(Journal.CONTENT_URI.buildUpon(),
										childId).build();

								getContentResolver().delete(uri, null, null);

								mGroupCursor.requery();
							}
						})
				.setNegativeButton(android.R.string.no,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog, int whichButton) {
							}
						}).create();
		ad.show();
	}

	private void deleteGroupJournal(int groupPos) {
		Cursor c = (Cursor) mExpandableAdapter.getGroup(groupPos);
		final long groupDate = c.getLong(mGroupPayDateGroupColumnIndex);
		String msg = MessageFormat.format(
				getString(R.string.confirm_delete_selected_group_journal),
				mDateFormat.format(groupDate));

		AlertDialog ad = new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_alert)
				.setTitle(android.R.string.dialog_alert_title)
				.setMessage(msg)
				.setPositiveButton(android.R.string.yes,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog, int whichButton) {
								long begin = groupDate;
								long end = begin + 86400000;

								getContentResolver()
										.delete(
												Journal.CONTENT_URI,
												Journal.COLUMN_PAY_DATE + " >= ?1 AND "
														+ Journal.COLUMN_PAY_DATE + " < ?2",
												new String[] { String.valueOf(begin),
														String.valueOf(end) });
								
								mGroupCursor.requery();
							}
						})
				.setNegativeButton(android.R.string.no,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog, int whichButton) {
							}
						}).create();
		ad.show();

	}

}
