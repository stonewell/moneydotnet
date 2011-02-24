package com.angelstone.android.dailyjournal.ui;

import java.text.MessageFormat;

import android.app.AlertDialog;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.text.SpannableString;
import android.text.format.DateFormat;
import android.text.style.StrikethroughSpan;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.CheckBox;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.ExpandableListContextMenuInfo;
import android.widget.ImageView;
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

	private static final int[][] OPTION_MENUS = new int[][] { new int[] {
			R.string.clear_all, android.R.drawable.ic_menu_delete }, };

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

			return managedQuery(Journal.CONTENT_PAY_DATE_LOCAL_TIME_URI, null,
					Journal.COLUMN_PAY_DATE_LOCAL + ">=" + begin + " AND "
							+ Journal.COLUMN_PAY_DATE_LOCAL + "<" + end, null,
					Journal.COLUMN_PAY_DATE_LOCAL + " desc");
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

	public AllJournalsView() {
		super(OPTION_MENUS.length);
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		// Query for pay date group
		mGroupCursor = managedQuery(Journal.CONTENT_PAY_DATE_GROUP_URI, null,
				null, null, null);

		mUseGroupView = true;// mGroupCursor.getCount() > 1;
		mDateFormat = DateFormat.getDateFormat(this);

		if (mUseGroupView) {
			setContentView(R.layout.all_journals_expandable);
			// Cache the ID column index
			mGroupPayDateGroupColumnIndex = mGroupCursor
					.getColumnIndexOrThrow(Journal.COLUMN_PAY_DATE_GROUP);

			// Set up our adapter
			mExpandableAdapter = new JournalPayDateGroupAdapter(mGroupCursor,
					this, android.R.layout.simple_expandable_list_item_1,
					R.layout.journal_list_item);

			ExpandableListView view = (ExpandableListView) findViewById(R.id.list);
			view.setAdapter(mExpandableAdapter);
			registerForContextMenu(view);
		} else {
			setContentView(R.layout.all_journals_list);

			Cursor journalCursor = managedQuery(Journal.CONTENT_URI, null,
					null, null, Journal.COLUMN_PAY_DATE + " desc");

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

		tv.setTextAppearance(context, android.R.style.TextAppearance_Medium);
		tv.setTextColor(color);

		int deleted = cursor.getInt(cursor
				.getColumnIndex(Journal.COLUMN_DELETED));
		int sync = cursor.getInt(cursor.getColumnIndex(Journal.COLUMN_SYNC));

		ImageView img = (ImageView) view.findViewById(R.id.imgsync);
		if (sync == Constants.SYNC_DONE) {
			img.setImageResource(android.R.drawable.star_on);
		} else {
			img.setImageResource(R.drawable.empty);
		}

		String text = MessageFormat.format(
				context.getString(R.string.pay_date_group_child_template),
				new Object[] {
						cursor.getDouble(cursor
								.getColumnIndex(Journal.COLUMN_AMOUNT)),
						cursor.getString(cursor
								.getColumnIndex(Journal.COLUMN_PAY_METHOD)),
						cursor.getString(cursor
								.getColumnIndex(Journal.COLUMN_NAME)),
						cursor.getString(cursor
								.getColumnIndex(Journal.COLUMN_CATEGORY)),
						typeStr });

		SpannableString spanText = new SpannableString(text);

		if (deleted == 1) {
			spanText.setSpan(new StrikethroughSpan(), 0, text.length(), 0);
		}

		tv.setText(spanText);
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
			menu.add(0, 1, 1, R.string.edit);
		menu.add(0, 2, 2, R.string.delete);

		super.onCreateContextMenu(menu, v, menuInfo);

	}

	public boolean onContextItemSelected(MenuItem item) {
		ContextMenuInfo menuInfo = item.getMenuInfo();
		boolean clickOnGroup = false;
		int groupPos = 0;
		long childId = 0;
		long packedPos = 0;

		if (menuInfo instanceof ExpandableListContextMenuInfo) {
			ExpandableListContextMenuInfo info = (ExpandableListContextMenuInfo) menuInfo;

			clickOnGroup = ExpandableListView
					.getPackedPositionType(info.packedPosition) == ExpandableListView.PACKED_POSITION_TYPE_GROUP;

			groupPos = ExpandableListView
					.getPackedPositionGroup(info.packedPosition);

			packedPos = info.packedPosition;

			if (!clickOnGroup) {
				childId = info.id;
			}
		} else if (menuInfo instanceof AdapterContextMenuInfo) {
			AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
			childId = info.id;
			packedPos = info.position;
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
				deleteJournal(childId, packedPos,
						menuInfo instanceof ExpandableListContextMenuInfo);
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

	private void deleteJournal(final long childId, long packedPos,
			boolean expand) {

		Cursor c = null;

		if (expand) {
			int groupPos = ExpandableListView.getPackedPositionGroup(packedPos);
			int childPos = ExpandableListView.getPackedPositionChild(packedPos);
			c = (Cursor) mExpandableAdapter.getChild(groupPos, childPos);
		} else {
			c = (Cursor) mJournalAdapter.getItem((int) packedPos * -1);
		}

		final int synced = c.getInt(c.getColumnIndex(Journal.COLUMN_SYNC));

		AlertDialog ad = new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_alert)
				.setTitle(android.R.string.dialog_alert_title)
				.setMessage(R.string.confirm_delete_selected_journal)
				.setPositiveButton(android.R.string.yes,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {
								Uri uri = ContentUris.appendId(
										Journal.CONTENT_URI.buildUpon(),
										childId).build();

								if (synced == Constants.SYNC_DONE) {
									ContentValues values = new ContentValues();
									values.put(Journal.COLUMN_DELETED, 1);
									values.put(Journal.COLUMN_SYNC,
											Constants.SYNC_NONE);

									getContentResolver().update(uri, values,
											null, null);
								} else {
									getContentResolver()
											.delete(uri, null, null);
								}
								mGroupCursor.requery();
							}
						})
				.setNegativeButton(android.R.string.no,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {
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

		new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_alert)
				.setTitle(android.R.string.dialog_alert_title)
				.setMessage(msg)
				.setPositiveButton(android.R.string.yes,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {
								long begin = groupDate;
								long end = begin + 86400000;

								deleteNotUploadedEntry(begin, end);
								updateUploadedEntry(begin, end);

								mGroupCursor.requery();
							}
						}).setNegativeButton(android.R.string.no, null).show();
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
			clearAll();
			break;
		}
		default:
			return super.onOptionsItemSelected(item);
		}
		return true;
	}

	private void clearAll() {
		// This example shows how to add a custom layout to an AlertDialog
		LayoutInflater factory = LayoutInflater.from(this);
		final View textEntryView = factory.inflate(
				R.layout.alert_dialog_checkbox_entry, null);

		new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_info)
				.setTitle(R.string.clear_history)
				.setView(textEntryView)
				.setPositiveButton(android.R.string.ok,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {
								CheckBox chk = (CheckBox) textEntryView
										.findViewById(R.id.checkbox_entry);

								if (chk.isChecked()) {
									getContentResolver().delete(
											Journal.CONTENT_URI, null, null);
								} else {
									// delete synced entry
									getContentResolver()
											.delete(Journal.CONTENT_URI,
													Journal.COLUMN_SYNC
															+ " = "
															+ Constants.SYNC_DONE,
													null);
								}

								mGroupCursor.requery();
							}
						}).setNegativeButton(android.R.string.cancel, null)
				.show();
	}

	private void updateUploadedEntry(long begin, long end) {
		Cursor c = null;

		try {
			c = getContentResolver().query(
					Journal.CONTENT_PAY_DATE_LOCAL_TIME_URI,
					new String[] { Journal.COLUMN_ID },
					Journal.COLUMN_PAY_DATE_LOCAL + ">=" + begin + " AND "
							+ Journal.COLUMN_PAY_DATE_LOCAL + "<" + end
							+ " AND " + Journal.COLUMN_SYNC + " = "
							+ Constants.SYNC_DONE, null, null);

			if (c.getCount() > 0) {
				StringBuffer sb = new StringBuffer(256);
				while (c.moveToNext()) {
					if (sb.length() > 0)
						sb.append(",");
					sb.append(c.getLong(0));
				}

				ContentValues values = new ContentValues();
				values.put(Journal.COLUMN_DELETED, 1);
				values.put(Journal.COLUMN_SYNC, Constants.SYNC_NONE);

				getContentResolver()
						.update(Journal.CONTENT_URI,
								values,
								Journal.COLUMN_ID + " IN (" + sb.toString()
										+ ")", null);
			}
		} finally {
			if (c != null)
				c.close();
		}
	}

	private void deleteNotUploadedEntry(long begin, long end) {
		Cursor c = null;

		try {
			c = getContentResolver().query(
					Journal.CONTENT_PAY_DATE_LOCAL_TIME_URI,
					new String[] { Journal.COLUMN_ID },
					Journal.COLUMN_PAY_DATE_LOCAL + ">=" + begin + " AND "
							+ Journal.COLUMN_PAY_DATE_LOCAL + "<" + end
							+ " AND " + Journal.COLUMN_SYNC + " = "
							+ Constants.SYNC_NONE + " AND "
							+ Journal.COLUMN_DELETED + "=0", null, null);

			if (c.getCount() > 0) {
				StringBuffer sb = new StringBuffer(256);
				while (c.moveToNext()) {
					if (sb.length() > 0)
						sb.append(",");
					sb.append(c.getLong(0));
				}

				getContentResolver()
						.delete(Journal.CONTENT_URI,
								Journal.COLUMN_ID + " IN (" + sb.toString()
										+ ")", null);
			}
		} finally {
			if (c != null)
				c.close();
		}
	}
}
