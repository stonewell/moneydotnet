package com.angelstone.android.dailyjournal.provider;

import android.content.ContentProvider;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.UriMatcher;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteQueryBuilder;
import android.net.Uri;
import android.text.TextUtils;

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
	private static final int JOURNAL_NAME = 9;
	private static final int JOURNAL_NAME_CATEGORY = 10;
	private static final int PAY_METHOD_ORDER_COUNT = 11;
	private static final int CATEGORY_ORDER_COUNT = 12;
	private static final int JOURNAL_PAY_DATE_GROUP = 13;

	private static UriMatcher sUriMatcher = null;
	static {
		sUriMatcher = new UriMatcher(UriMatcher.NO_MATCH);
		sUriMatcher.addURI(AUTHORITY, "journal", JOURNAL);
		sUriMatcher.addURI(AUTHORITY, "journal/name", JOURNAL_NAME);
		sUriMatcher.addURI(AUTHORITY, "journal/name/category",
				JOURNAL_NAME_CATEGORY);
		sUriMatcher.addURI(AUTHORITY, "journal/group/pay_date",
				JOURNAL_PAY_DATE_GROUP);
		sUriMatcher.addURI(AUTHORITY, "journal/#", JOURNAL_ID);
		sUriMatcher.addURI(AUTHORITY, "settings", SETTINGS);
		sUriMatcher.addURI(AUTHORITY, "settings/#", SETTINGS_ID);
		sUriMatcher.addURI(AUTHORITY, "category", CATEGORY);
		sUriMatcher.addURI(AUTHORITY, "category/order/count", CATEGORY_ORDER_COUNT);
		sUriMatcher.addURI(AUTHORITY, "category/#", CATEGORY_ID);
		sUriMatcher.addURI(AUTHORITY, "paymethod", PAY_METHOD);
		sUriMatcher.addURI(AUTHORITY, "paymethod/order/count",
				PAY_METHOD_ORDER_COUNT);
		sUriMatcher.addURI(AUTHORITY, "paymethod/#", PAY_METHOD_ID);
	}

	private DailyJournalDatabaseHelper mOpenHelper;

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
			count = db.delete(JOURNAL_TABLE, Journal.COLUMN_ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case CATEGORY:
			count = db.delete(CATEGORY_TABLE, where, whereArgs);
			break;

		case CATEGORY_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(CATEGORY_TABLE, Category.COLUMN_ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case PAY_METHOD:
			count = db.delete(PAY_METHOD_TABLE, where, whereArgs);
			break;

		case PAY_METHOD_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(PAY_METHOD_TABLE, PayMethod.COLUMN_ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case SETTINGS: {
			count = db.delete(SETTING_TABLE, where, whereArgs);
		}
		case SETTINGS_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.delete(SETTING_TABLE, Setting.COLUMN_ID + "=" + id
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
		case JOURNAL_NAME:
		case JOURNAL_NAME_CATEGORY:
			return Journal.CONTENT_ITEM_TYPE;
		case SETTINGS:
			return Setting.CONTENT_TYPE;
		case SETTINGS_ID:
			return Setting.CONTENT_ITEM_TYPE;
		case CATEGORY:
			return Category.CONTENT_TYPE;
		case CATEGORY_ID:
		case CATEGORY_ORDER_COUNT:
			return Category.CONTENT_ITEM_TYPE;
		case PAY_METHOD:
			return PayMethod.CONTENT_TYPE;
		case PAY_METHOD_ID:
		case PAY_METHOD_ORDER_COUNT:
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
			rowId = db.insert(JOURNAL_TABLE, Journal.COLUMN_NAME, values);
		else if (match == SETTINGS)
			rowId = db.insert(SETTING_TABLE, Setting.COLUMN_OPTION, values);
		else if (match == CATEGORY)
			rowId = db.insert(CATEGORY_TABLE, Category.COLUMN_NAME, values);
		else
			rowId = db.insert(PAY_METHOD_TABLE, PayMethod.COLUMN_NAME, values);

		if (rowId > 0) {
			Uri notifyUri = ContentUris.withAppendedId(uri, rowId);
			getContext().getContentResolver().notifyChange(notifyUri, null);
			return notifyUri;
		}

		throw new SQLException("Failed to insert row into " + uri);
	}

	@Override
	public boolean onCreate() {
		mOpenHelper = new DailyJournalDatabaseHelper(getContext());
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
			qb.appendWhere(Journal.COLUMN_ID + "=" + uri.getPathSegments().get(1));
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Journal.DEFAULT_SORT_ORDER;
			break;

		case JOURNAL_NAME: {
			qb.setTables(JOURNAL_NAME_WITH_ID_VIEW);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = "count desc";
			break;
		}

		case JOURNAL_NAME_CATEGORY: {
			qb.setTables(JOURNAL_NAME_CATEGORY_WITH_ID_VIEW);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = "count desc";
			break;
		}
		case SETTINGS:
			qb.setTables(SETTING_TABLE);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Setting.DEFAULT_SORT_ORDER;
			break;

		case SETTINGS_ID:
			qb.setTables(SETTING_TABLE);
			qb.appendWhere(Setting.COLUMN_ID + "=" + uri.getPathSegments().get(1));
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
			qb.appendWhere(Category.COLUMN_ID + "=" + uri.getPathSegments().get(1));
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
			qb.appendWhere(PayMethod.COLUMN_ID + "=" + uri.getPathSegments().get(1));
			if (TextUtils.isEmpty(sortOrder))
				orderBy = PayMethod.DEFAULT_SORT_ORDER;
			break;
		case CATEGORY_ORDER_COUNT: {
			qb.setTables(CATEGORY_USE_COUNT_VIEW);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = "count desc";
			break;
		}
		case PAY_METHOD_ORDER_COUNT: {
			qb.setTables(PAY_METHOD_USE_COUNT_VIEW);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = "count desc";
			break;
		}
		case JOURNAL_PAY_DATE_GROUP: {
			qb.setTables(JOURNAL_PAY_DATE_GROUP_WITH_ID_VIEW);
			if (TextUtils.isEmpty(sortOrder))
				orderBy = Journal.COLUMN_PAY_DATE_GROUP + " desc";
			break;
		}
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
			count = db.update(JOURNAL_TABLE, values, Journal.COLUMN_ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case SETTINGS:
			count = db.update(SETTING_TABLE, values, where, whereArgs);
			break;

		case SETTINGS_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(SETTING_TABLE, values, Setting.COLUMN_ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case CATEGORY:
			count = db.update(CATEGORY_TABLE, values, where, whereArgs);
			break;

		case CATEGORY_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(CATEGORY_TABLE, values, Category.COLUMN_ID + "=" + id
					+ (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
					whereArgs);
			break;
		}
		case PAY_METHOD:
			count = db.update(PAY_METHOD_TABLE, values, where, whereArgs);
			break;

		case PAY_METHOD_ID: {
			String id = uri.getPathSegments().get(1);
			count = db.update(PAY_METHOD_TABLE, values, PayMethod.COLUMN_ID + "="
					+ id + (!TextUtils.isEmpty(where) ? " AND (" + where + ')' : ""),
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
