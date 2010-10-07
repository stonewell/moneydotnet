package com.angelstone.android.dailyjournal;

import java.util.UUID;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.util.Log;

public class DatabaseManager {

	public static boolean writeSettingString(Context context, String option_name,
			String option_value) {
		Cursor cur = null;

		try {
			String where_str = Setting.COLUMN_OPTION + "=?";
			cur = context.getContentResolver().query(Setting.CONTENT_URI,
					new String[] { Setting.COLUMN_ID }, where_str,
					new String[] { option_name }, null);

			if (cur == null) {
				return false;
			}

			ContentValues args = new ContentValues();

			if (cur.getCount() == 0) {
				args.put(Setting.COLUMN_OPTION, option_name);
				args.put(Setting.COLUMN_VALUE, option_value);
				context.getContentResolver().insert(Setting.CONTENT_URI, args);
			} else {
				args.put(Setting.COLUMN_VALUE, option_value);
				context.getContentResolver().update(Setting.CONTENT_URI, args,
						where_str, new String[] { option_name });

			}
		} catch (Exception e) {
			return false;
		} finally {
			if (cur != null) {
				cur.close();
			}
		}

		return true;
	}

	public static boolean writeSetting(Context context, String option_name,
			boolean option_value) {
		return writeSettingString(context, option_name, option_value ? "1" : "0");
	}

	public static String readSettingString(Context context, String option_name,
			String def_value) {
		Cursor cur = null;

		try {
			String where_str = Setting.COLUMN_OPTION + "=?";
			cur = context.getContentResolver().query(Setting.CONTENT_URI,
					new String[] { Setting.COLUMN_VALUE }, where_str,
					new String[] { option_name }, null);

			if (cur == null) {
				return def_value;
			}

			if (!cur.moveToFirst())
				return def_value;

			int idx = cur.getColumnIndex(Setting.COLUMN_VALUE);

			return cur.isNull(idx) ? def_value : cur.getString(idx);
		} catch (Exception e) {
			Log.e(Constants.TAG, e.getLocalizedMessage(), e);

			return def_value;
		} finally {
			if (cur != null) {
				cur.close();
			}
		}
	}

	public static boolean readSetting(Context context, String option_name) {
		return "1".equals(readSettingString(context, option_name, "0"));
	}

	public static String generateUid() {
		return UUID.randomUUID().toString();
	}
}
