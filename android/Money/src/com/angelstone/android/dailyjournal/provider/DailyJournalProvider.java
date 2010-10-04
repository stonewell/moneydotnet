package com.angelstone.android.dailyjournal.provider;

import android.content.ContentProvider;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.Context;
import android.content.UriMatcher;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.database.sqlite.SQLiteQueryBuilder;
import android.net.Uri;
import android.text.TextUtils;
import android.util.Log;

import com.angelstone.android.dailyjournal.Category;
import com.angelstone.android.dailyjournal.Constants;
import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.PayMethod;
import com.angelstone.android.dailyjournal.Setting;

public class DailyJournalProvider extends ContentProvider implements Constants {
	private static final int JOURNAL = 1;
	private static final int JOURNAL_ID = 2;
	private static final int SETTINGS = 3;
	private static final int SETTINGS_ID = 4;
	private static final int CATEGORY = 5;
	private static final int CATEGORY_ID = 6;
	private static final int PAY_METHOD = 7;
	private static final int PAY_METHOD_ID = 8;

	private static UriMatcher sUriMatcher = null;
	static {
		sUriMatcher = new UriMatcher(UriMatcher.NO_MATCH);
		sUriMatcher.addURI(AUTHORITY, "journal", JOURNAL);
		sUriMatcher.addURI(AUTHORITY, "journal/#", JOURNAL_ID);
		sUriMatcher.addURI(AUTHORITY, "settings", SETTINGS);
		sUriMatcher.addURI(AUTHORITY, "settings/#", SETTINGS_ID);
		sUriMatcher.addURI(AUTHORITY, "category", CATEGORY);
		sUriMatcher.addURI(AUTHORITY, "category/#", CATEGORY_ID);
		sUriMatcher.addURI(AUTHORITY, "paymethod", PAY_METHOD);
		sUriMatcher.addURI(AUTHORITY, "paymethod/#", PAY_METHOD_ID);
	}

	/**
	 * This class helps open, create, and upgrade the database file.
	 */
	private static class DatabaseHelper extends SQLiteOpenHelper {

		DatabaseHelper(Context context) {
			super(context, DATABASE_NAME, null, DATABASE_VERSION);
		}

		@Override
		public void onCreate(SQLiteDatabase db) {
			db.execSQL("CREATE TABLE IF NOT EXISTS " + SETTING_TABLE + " ("
					+ Setting._ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
					+ Setting.OPTION + " VARCHAR, " + Setting.VALUE + " VARCHAR);");
			db.execSQL("CREATE TABLE IF NOT EXISTS " + JOURNAL_TABLE + " ("
					+ Journal._ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " + Journal.NAME
					+ " VARCHAR, " + Journal.AMOUNT + " DOUBLE, " + Journal.CATEGORY
					+ " VARCHAR, " + Journal.PAY_METHOD + " VARCHAR, " + Journal.TYPE
					+ " INTEGER, " + Journal.PAY_DATE + " LONG, " + Journal.CREATE_DATE
					+ " LONG, " + Journal.DESCRIPTION + " TEXT, " + ");");
			db.execSQL("CREATE TABLE IF NOT EXISTS " + CATEGORY_TABLE + " ("
					+ Category._ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
					+ Category.NAME + " VARCHAR);");
			db.execSQL("CREATE TABLE IF NOT EXISTS " + PAY_METHOD_TABLE + " ("
					+ PayMethod._ID + " INTEGER PRIMARY KEY AUTOINCREMENT, "
					+ PayMethod.NAME + " VARCHAR);");
		}

		@Override
		public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
			Log.w(TAG, "Upgrading database from version " + oldVersion + " to "
					+ newVersion + ", which will destroy all old data");
			db.execSQL("DROP TABLE IF EXISTS " + SETTING_TABLE);
			db.execSQL("DROP TABLE IF EXISTS " + JOURNAL_TABLE);
			db.execSQL("DROP TABLE IF EXISTS " + CATEGORY_TABLE);
			db.execSQL("DROP TABLE IF EXISTS " + PAY_METHOD_TABLE);
			onCreate(db);
		}
	}

	private DatabaseHelper mOpenHelper;

	@Override
	public int delete(Uri uri, String where, String[] whereArgs) {
		SQLiteDatabase db = mOpenHelper.getWritableDatabase();
		int count;
		switch (sUriMatcher.match(uri)) {
		case JOURNAL:
			count = db.delete(JOURNAL_TABLE, where, whereArgs);
			break;

		case JOURNAL_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(JOURNAL_TABLE,
					Journal._ID + "=" + id
							+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case CATEGORY:
			count = db.delete(CATEGORY_TABLE, where, whereArgs);
			break;

		case CATEGORY_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(CATEGORY_TABLE,
					Category._ID + "=" + id
							+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case PAY_METHOD:
			count = db.delete(CATEGORY_TABLE, where, whereArgs);
			break;

		case PAY_METHOD_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(PAY_METHOD_TABLE, PayMethod._ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case SETTINGS: {
			count = db.delete(SETTING_TABLE, where, whereArgs);
		}
		case SETTINGS_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(SETTING_TABLE,
					Setting._ID + "=" + id
							+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		default:
			throw new IllegalArgumentException("Unknown URI " + uri);
		}

		getContext().getContentResolver().notifyChange(uri, null);
		return count;
	}

	@Override
	public String getType(Uri uri) {
		switch (sUriMatcher.match(uri)) {
		case JOURNAL:
			return Journal.CONTENT_TYPE;
		case JOURNAL_ID:
			return Journal.CONTENT_ITEM_TYPE;
		case SETTINGS:
			return Setting.CONTENT_TYPE;
		case SETTINGS_ID:
			return Setting.CONTENT_ITEM_TYPE;
		case CATEGORY:
			return Category.CONTENT_TYPE;
		case CATEGORY_ID:
			return Category.CONTENT_ITEM_TYPE;
		case PAY_METHOD:
			return PayMethod.CONTENT_TYPE;
		case PAY_METHOD_ID:
			return PayMethod.CONTENT_ITEM_TYPE;
		default:
			throw new IllegalArgumentException("Unknown URI " + uri);
		}
	}

	@Override
	public Uri insert(Uri uri, ContentValues values) {
		// Validate the requested uri
		int match = sUriMatcher.match(uri);
		if (match != JOURNAL && match != SETTINGS && match != CATEGORY
				&& match != PAY_METHOD) {
			throw new IllegalArgumentException("Unknown URI " + uri);
		}

		SQLiteDatabase db = mOpenHelper.getWritableDatabase();
		long rowId = 0;

		if (match == JOURNAL)
			rowId = db.insert(JOURNAL_TABLE, Journal.NAME, values);
		else if (match == SETTINGS)
			rowId = db.insert(SETTING_TABLE, Setting.OPTION, values);
		else if (match == CATEGORY)
			rowId = db.insert(CATEGORY_TABLE, Category.NAME, values);
		else
			rowId = db.insert(PAY_METHOD_TABLE, PayMethod.NAME, values);

		if (rowId > 0) {
			Uri notifyUri = ContentUris.withAppendedId(uri, rowId);
			getContext().getContentResolver().notifyChange(notifyUri, null);
			return notifyUri;
		}

		throw new SQLException("Failed to insert row into " + uri);
	}

	@Override
	public boolean onCreate() {
		mOpenHelper = new DatabaseHelper(getContext());
		return true;
	}

	@Override
	public Cursor query(Uri uri, String[] projection, String selection,
			String[] selectionArgs, String sortOrder) {
		SQLiteQueryBuilder qb = new SQLiteQueryBuilder();

		String orderBy = sortOrder;
		switch (sUriMatcher.match(uri)) {
		case JOURNAL:
			qb.setTables(JOURNAL_TABLE);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Journal.DEFAULT_SORT_ORDER;
			break;

		case JOURNAL_ID:
			qb.setTables(JOURNAL_TABLE);
			qb.appendWhere(Journal._ID + "=" + uri.getPathSegments().get(1));
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Journal.DEFAULT_SORT_ORDER;
			break;

		case SETTINGS:
			qb.setTables(SETTING_TABLE);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Setting.DEFAULT_SORT_ORDER;
			break;

		case SETTINGS_ID:
			qb.setTables(SETTING_TABLE);
			qb.appendWhere(Setting._ID + "=" + uri.getPathSegments().get(1));
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Setting.DEFAULT_SORT_ORDER;
			break;
		case CATEGORY:
			qb.setTables(CATEGORY_TABLE);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Category.DEFAULT_SORT_ORDER;
			break;

		case CATEGORY_ID:
			qb.setTables(CATEGORY_TABLE);
			qb.appendWhere(Category._ID + "=" + uri.getPathSegments().get(1));
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Category.DEFAULT_SORT_ORDER;
			break;
		case PAY_METHOD:
			qb.setTables(PAY_METHOD_TABLE);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = PayMethod.DEFAULT_SORT_ORDER;
			break;

		case PAY_METHOD_ID:
			qb.setTables(PAY_METHOD_TABLE);
			qb.appendWhere(PayMethod._ID + "=" + uri.getPathSegments().get(1));
			if (TextUtils.isEmpty(sortOrder))
				orderBy = PayMethod.DEFAULT_SORT_ORDER;
			break;
		default:
			throw new IllegalArgumentException("Unknown URI " + uri);
		}

		// Get the database and run the query
		SQLiteDatabase db = mOpenHelper.getReadableDatabase();
		Cursor c = qb.query(db, projection, selection, selectionArgs, null, null,
				orderBy);

		// Tell the cursor what uri to watch, so it knows when its source data
		// changes
		c.setNotificationUri(getContext().getContentResolver(), uri);
		return c;
	}

	@Override
	public int update(Uri uri, ContentValues values, String where,
			String[] whereArgs) {
		SQLiteDatabase db = mOpenHelper.getWritableDatabase();
		int count;
		switch (sUriMatcher.match(uri)) {
		case JOURNAL:
			count = db.update(JOURNAL_TABLE, values, where, whereArgs);
			break;

		case JOURNAL_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(JOURNAL_TABLE, values, Journal._ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case SETTINGS:
			count = db.update(SETTING_TABLE, values, where, whereArgs);
			break;

		case SETTINGS_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(SETTING_TABLE, values, Setting._ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case CATEGORY:
			count = db.update(CATEGORY_TABLE, values, where, whereArgs);
			break;

		case CATEGORY_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(CATEGORY_TABLE, values, Category._ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case PAY_METHOD:
			count = db.update(PAY_METHOD_TABLE, values, where, whereArgs);
			break;

		case PAY_METHOD_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(PAY_METHOD_TABLE, values, PayMethod._ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		default:
			throw new IllegalArgumentException("Unknown URI " + uri);
		}

		getContext().getContentResolver().notifyChange(uri, null);
		return count;
	}

}
