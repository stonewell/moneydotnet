package com.angelstone.android.dailyjournal;

public interface Constants {
	public static final String TAG = "DailyJournal";

	public static final String DATABASE_NAME = "daily_journal.db";
	public static final int DATABASE_VERSION = 10;
	public static final String JOURNAL_TABLE = "journal";
	public static final String SETTING_TABLE = "setting";
	public static final String CATEGORY_TABLE = "category";
	public static final String PAY_METHOD_TABLE = "pay_method";
	public static final String JOURNAL_NAME_VIEW = "journal_name_view";
	public static final String JOURNAL_NAME_WITH_ID_VIEW = "journal_name_with_id_view";
	public static final String JOURNAL_NAME_CATEGORY_VIEW = "journal_name_category_view";
	public static final String JOURNAL_NAME_CATEGORY_WITH_ID_VIEW = "journal_name_category_with_id_view";
	public static final String CATEGORY_USE_COUNT_VIEW = "category_count_view";
	public static final String PAY_METHOD_USE_COUNT_VIEW = "paymethod_count_view";

	public static final String AUTHORITY = "com.angelstone.android.dailyjournal";

	public static final String COLUMN_ID = "_id";

	public static final String COLUMN_NAME = "name";

	public static final String OPTION_DATA_INIT = "data_init";

	public static final int SYNC_DONE = 1;
	public static final int SYNC_NONE = 0;

	public static final String PARAM_ENTRIES = "entries";

	public static final String COLUMN_COUNT = "count";

	public static final String JOURNAL_PAY_DATE_GROUP_VIEW = "journal_pay_date_group_view";
	public static final String JOURNAL_PAY_DATE_GROUP_WITH_ID_VIEW = "journal_pay_date_group_with_id_view";
	
	public static final String ACTION_EDIT_JOURNAL = "angelstone.android.dailyjournal.action.EDIT";
	public static final String ACTION_EDIT_CATEGORY = "angelstone.android.dailyjournal.action.category.EDIT";
	public static final String ACTION_EDIT_PAY_METHOD = "angelstone.android.dailyjournal.action.paymethod.EDIT";
	
	public static final int NOTIFY_UPLOAD_DONE = 1;
}
