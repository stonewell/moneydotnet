package com.angelstone.android.dailyjournal;

import android.net.Uri;

public class PayMethod implements Constants {
	public static final Uri CONTENT_SETTINGS_URI = Uri.parse("content://"
			+ AUTHORITY + "/paymethod");
	public static final String CONTENT_TYPE = "vnd.android.cursor.dir/vnd.angelstone.android.dailyjournal.paymethod";
	public static final String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/vnd.angelstone.android.dailyjournal.paymethod";

	public static final String _ID = "_id";

	public static final String NAME = "name";

	public static final String DEFAULT_SORT_ORDER = NAME + " desc";

	public String Name;

}
