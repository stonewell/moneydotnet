package com.angelstone.android.dailyjournal;

import android.net.Uri;

public class Category implements Constants{
	public static final Uri CONTENT_URI = Uri.parse("content://"
			+ AUTHORITY + "/category");
	public static final Uri CONTENT_ORDER_COUNT_URI = Uri.parse("content://"
			+ AUTHORITY + "/category/order/count");
	public static final String CONTENT_TYPE = "vnd.android.cursor.dir/vnd.angelstone.android.dailyjournal.category";
  public static final String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/vnd.angelstone.android.dailyjournal.category";

	public static final String DEFAULT_SORT_ORDER = COLUMN_NAME + " desc";

	public String Name;

}
