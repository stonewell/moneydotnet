package com.angelstone.android.dailyjournal.provider;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import com.angelstone.android.dailyjournal.Category;
import com.angelstone.android.dailyjournal.Constants;
import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.PayMethod;
import com.angelstone.android.dailyjournal.Setting;

/**
 * This class helps open, create, and upgrade the database file.
 */
public class DailyJournalDatabaseHelper extends SQLiteOpenHelper {

	DailyJournalDatabaseHelper(Context context) {
		super(context, Constants.DATABASE_NAME, null, Constants.DATABASE_VERSION);
	}

	@Override
	public void onCreate(SQLiteDatabase db) {
		db.execSQL("CREATE TABLE IF NOT EXISTS " + Constants.SETTING_TABLE + " ("
				+ Setting.COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
				+ Setting.COLUMN_OPTION + " VARCHAR, " + Setting.COLUMN_VALUE
				+ " VARCHAR);");
		db.execSQL("CREATE TABLE IF NOT EXISTS " + Constants.JOURNAL_TABLE + " ("
				+ Journal.COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
				+ Journal.COLUMN_SYNC + " INTEGER, " + Journal.COLUMN_NAME
				+ " VARCHAR, " + Journal.COLUMN_AMOUNT + " DOUBLE, "
				+ Journal.COLUMN_CATEGORY + " VARCHAR, " + Journal.COLUMN_PAY_METHOD
				+ " VARCHAR, " + Journal.COLUMN_TYPE + " INTEGER, "
				+ Journal.COLUMN_PAY_DATE + " LONG, " + Journal.COLUMN_CREATE_DATE
				+ " LONG, " + Journal.COLUMN_DESCRIPTION + " TEXT " + ");");
		db.execSQL("CREATE TABLE IF NOT EXISTS " + Constants.CATEGORY_TABLE + " ("
				+ Category.COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
				+ Category.COLUMN_NAME + " VARCHAR);");
		db.execSQL("CREATE TABLE IF NOT EXISTS " + Constants.PAY_METHOD_TABLE
				+ " (" + PayMethod.COLUMN_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
				+ PayMethod.COLUMN_NAME + " VARCHAR);");

		db.execSQL("CREATE VIEW IF NOT EXISTS " + Constants.JOURNAL_NAME_VIEW
				+ " AS SELECT " + Constants.COLUMN_NAME + ", COUNT(*) as "
				+ Constants.COLUMN_COUNT + " FROM " + Constants.JOURNAL_TABLE
				+ " GROUP BY " + Constants.COLUMN_NAME + ";");
		db.execSQL("CREATE VIEW IF NOT EXISTS "
				+ Constants.JOURNAL_NAME_WITH_ID_VIEW + " AS SELECT "
				+ "(select count(*) from " + Constants.JOURNAL_NAME_VIEW + " t1 where "
				+ "t1." + Constants.COLUMN_NAME + " < t2." + Constants.COLUMN_NAME
				+ ") as " + Constants.COLUMN_ID + "," + Constants.COLUMN_NAME + ","
				+ Constants.COLUMN_COUNT + " FROM " + Constants.JOURNAL_NAME_VIEW
				+ " t2;");
		db.execSQL("CREATE VIEW IF NOT EXISTS "
				+ Constants.JOURNAL_NAME_CATEGORY_VIEW + " AS SELECT "
				+ Constants.COLUMN_NAME + ", " + Journal.COLUMN_CATEGORY
				+ ", COUNT(*) as count FROM " + Constants.JOURNAL_TABLE + " GROUP BY "
				+ Constants.COLUMN_NAME + ", " + Journal.COLUMN_CATEGORY + ";");
		db.execSQL("CREATE VIEW IF NOT EXISTS "
				+ Constants.JOURNAL_NAME_CATEGORY_WITH_ID_VIEW + " AS SELECT "
				+ "(select count(*) from " + Constants.JOURNAL_NAME_CATEGORY_VIEW
				+ " t1 where " + "t1." + Constants.COLUMN_NAME + " < t2."
				+ Constants.COLUMN_NAME + " OR " + "(t1." + Constants.COLUMN_NAME
				+ " = t2." + Constants.COLUMN_NAME + " AND " + "t1."
				+ Journal.COLUMN_CATEGORY + " < t2." + Journal.COLUMN_CATEGORY
				+ ")) as " + Constants.COLUMN_ID + "," + Constants.COLUMN_NAME + ","
				+ Journal.COLUMN_CATEGORY + "," + Constants.COLUMN_COUNT + " FROM "
				+ Constants.JOURNAL_NAME_CATEGORY_VIEW + " t2;");
		db.execSQL("CREATE VIEW IF NOT EXISTS " + Constants.CATEGORY_USE_COUNT_VIEW
				+ " AS SELECT " + "(select count(*) FROM " + Constants.JOURNAL_TABLE
				+ " t1" + " WHERE t1." + Journal.COLUMN_CATEGORY + "= t2."
				+ Constants.COLUMN_NAME + ") as " + Constants.COLUMN_COUNT + ","
				+ Constants.COLUMN_NAME + "," + Constants.COLUMN_ID + " FROM "
				+ Constants.CATEGORY_TABLE + " t2;");
		db.execSQL("CREATE VIEW IF NOT EXISTS "
				+ Constants.PAY_METHOD_USE_COUNT_VIEW + " AS SELECT "
				+ "(select count(*) FROM " + Constants.JOURNAL_TABLE + " t1"
				+ " WHERE t1." + Journal.COLUMN_PAY_METHOD + "= t2."
				+ Constants.COLUMN_NAME + ") as " + Constants.COLUMN_COUNT + ","
				+ Constants.COLUMN_NAME + "," + Constants.COLUMN_ID + " FROM "
				+ Constants.PAY_METHOD_TABLE + " t2;");
		db.execSQL("CREATE VIEW IF NOT EXISTS "
				+ Constants.JOURNAL_PAY_DATE_GROUP_VIEW + " AS SELECT "
				+ " DISTINCT (pay_date / 86400000 * 86400000) as "
				+ Journal.COLUMN_PAY_DATE_GROUP + " FROM " + Constants.JOURNAL_TABLE
				+ ";");
		db.execSQL("CREATE VIEW IF NOT EXISTS "
				+ Constants.JOURNAL_PAY_DATE_GROUP_WITH_ID_VIEW + " AS SELECT "
				+ "(select count(*) from " + Constants.JOURNAL_PAY_DATE_GROUP_VIEW + " t1 where "
				+ "t1." + Journal.COLUMN_PAY_DATE_GROUP + " < t2." + Journal.COLUMN_PAY_DATE_GROUP
				+ ") as " + Constants.COLUMN_ID + "," + Journal.COLUMN_PAY_DATE_GROUP
				+ " FROM " + Constants.JOURNAL_PAY_DATE_GROUP_VIEW
				+ " t2;");
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
		Log.w(Constants.TAG, "Upgrading database from version " + oldVersion
				+ " to " + newVersion + ", which will destroy all old data");
		if (oldVersion < 2) {
			db.execSQL("DROP TABLE IF EXISTS " + Constants.SETTING_TABLE);
			db.execSQL("DROP TABLE IF EXISTS " + Constants.JOURNAL_TABLE);
			db.execSQL("DROP TABLE IF EXISTS " + Constants.CATEGORY_TABLE);
			db.execSQL("DROP TABLE IF EXISTS " + Constants.PAY_METHOD_TABLE);
		}
		db.execSQL("DROP VIEW IF EXISTS " + Constants.JOURNAL_NAME_VIEW);
		db.execSQL("DROP VIEW IF EXISTS " + Constants.JOURNAL_NAME_CATEGORY_VIEW);
		db.execSQL("DROP VIEW IF EXISTS " + Constants.JOURNAL_NAME_WITH_ID_VIEW);
		db.execSQL("DROP VIEW IF EXISTS "
				+ Constants.JOURNAL_NAME_CATEGORY_WITH_ID_VIEW);
		db.execSQL("DROP VIEW IF EXISTS " + Constants.CATEGORY_USE_COUNT_VIEW);
		db.execSQL("DROP VIEW IF EXISTS " + Constants.PAY_METHOD_USE_COUNT_VIEW);
		db.execSQL("DROP VIEW IF EXISTS " + Constants.JOURNAL_PAY_DATE_GROUP_VIEW);
		onCreate(db);
	}
}