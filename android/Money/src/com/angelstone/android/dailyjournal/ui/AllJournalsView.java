package com.angelstone.android.dailyjournal.ui;

import com.angelstone.android.dailyjournal.Journal;

import android.app.ExpandableListActivity;
import android.content.ContentUris;
import android.content.Context;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.provider.Contacts.People;
import android.widget.ExpandableListAdapter;
import android.widget.SimpleCursorTreeAdapter;

public class AllJournalsView extends ExpandableListActivity {
  private ExpandableListAdapter mAdapter;

  @Override
  public void onCreate(Bundle savedInstanceState) {
      super.onCreate(savedInstanceState);

      // Query for people
      Cursor groupCursor = managedQuery(Journal.CONTENT_PAY_DATE_GROUP_URI, null, null, null, null);

      // Cache the ID column index
      mGroupIdColumnIndex = groupCursor.getColumnIndexOrThrow(People._ID);

      // Set up our adapter
      mAdapter = new MyExpandableListAdapter(groupCursor,
              this,
              android.R.layout.simple_expandable_list_item_1,
              android.R.layout.simple_expandable_list_item_1,
              new String[] {People.NAME}, // Name for group layouts
              new int[] {android.R.id.text1},
              new String[] {People.NUMBER}, // Number for child layouts
              new int[] {android.R.id.text1});
      setListAdapter(mAdapter);
  }

  public class MyExpandableListAdapter extends SimpleCursorTreeAdapter {

      public MyExpandableListAdapter(Cursor cursor, Context context, int groupLayout,
              int childLayout, String[] groupFrom, int[] groupTo, String[] childrenFrom,
              int[] childrenTo) {
          super(context, cursor, groupLayout, groupFrom, groupTo, childLayout, childrenFrom,
                  childrenTo);
      }

      @Override
      protected Cursor getChildrenCursor(Cursor groupCursor) {
          // Given the group, we return a cursor for all the children within that group 

          // Return a cursor that points to this contact's phone numbers
          Uri.Builder builder = People.CONTENT_URI.buildUpon();
          ContentUris.appendId(builder, groupCursor.getLong(mGroupIdColumnIndex));
          builder.appendEncodedPath(People.Phones.CONTENT_DIRECTORY);
          Uri phoneNumbersUri = builder.build();

          // The returned Cursor MUST be managed by us, so we use Activity's helper
          // functionality to manage it for us.
          return managedQuery(phoneNumbersUri, mPhoneNumberProjection, null, null, null);
      }

  }
}
