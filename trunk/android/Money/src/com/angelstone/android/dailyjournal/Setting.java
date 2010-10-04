package com.angelstone.android.dailyjournal;

import android.net.Uri;

public class Setting implements Constants {
	public static final Uri CONTENT_SETTINGS_URI = Uri.parse("content://"
			+ AUTHORITY + "/settings");
	public static final String CONTENT_TYPE = "vnd.android.cursor.dir/vnd.angelstone.android.dailyjournal.settings";
  public static final String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/vnd.angelstone.android.dailyjournal.settings";
	
	public static final String OPTION = "option";
	public static final String VALUE = "value";
	public static final String DEFAULT_SORT_ORDER = OPTION + " asc";
	public static final String _ID = "_id";

	public String Option;
	public String Value;
}
