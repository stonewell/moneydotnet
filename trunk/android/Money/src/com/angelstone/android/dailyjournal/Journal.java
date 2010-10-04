package com.angelstone.android.dailyjournal;

import java.util.Calendar;
import java.util.Date;

import android.net.Uri;

public class Journal implements Constants{
	public static final Uri CONTENT_SETTINGS_URI = Uri.parse("content://"
			+ AUTHORITY + "/journal");
	public static final String CONTENT_TYPE = "vnd.android.cursor.dir/vnd.angelstone.android.dailyjournal.journal";
  public static final String CONTENT_ITEM_TYPE = "vnd.android.cursor.item/vnd.angelstone.android.dailyjournal.journal";

  public static final String _ID = "_id";
	
	public static final String NAME = "name";
	public static final String AMOUNT = "amount";
	public static final String CATEGORY = "category";
	public static final String PAY_METHOD="pay_method";
	public static final String TYPE = "type";
	public static final String PAY_DATE = "pay_date";
	public static final String CREATE_DATE = "create_date";
	public static final String DESCRIPTION = "description";
	
	public static final String DEFAULT_SORT_ORDER = PAY_DATE + " desc";

	public String Name;
	public double Amount;
	public String Category;
	public String PayMethod;
	public int Type;
	public Date PayDate = Calendar.getInstance().getTime();
	public Date CreateDate = Calendar.getInstance().getTime();
	public String Description;
}
