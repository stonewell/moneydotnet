package com.angelstone.android.dailyjournal;

import java.util.Calendar;
import java.util.Date;

import android.net.Uri;

public class Journal implements Constants{
	public static final Uri CONTENT_URI = Uri.parse("content://"
			+ AUTHORITY + "/journal");
	public static final Uri CONTENT_NAME_URI = Uri.parse("content://"
			+ AUTHORITY + "/journal/name");
	public static final Uri CONTENT_NAME_CATEGORY_URI = Uri.parse("content://"
			+ AUTHORITY + "/journal/name/category");
	
	public static final String CONTENT_TYPE = "vnd.android.cursor.dir/vnd.angelstone.android.dailyjournal.journal";
  public static final String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/vnd.angelstone.android.dailyjournal.journal";

	public static final String COLUMN_AMOUNT = "amount";
	public static final String COLUMN_CATEGORY = "category";
	public static final String COLUMN_PAY_METHOD="pay_method";
	public static final String COLUMN_TYPE = "type";
	public static final String COLUMN_PAY_DATE = "pay_date";
	public static final String COLUMN_CREATE_DATE = "create_date";
	public static final String COLUMN_DESCRIPTION = "description";
	
	public static final String DEFAULT_SORT_ORDER = COLUMN_PAY_DATE + " desc";

	public String Name;
	public double Amount;
	public String Category;
	public String PayMethod;
	public int Type;
	public Date PayDate = Calendar.getInstance().getTime();
	public Date CreateDate = Calendar.getInstance().getTime();
	public String Description;
}
