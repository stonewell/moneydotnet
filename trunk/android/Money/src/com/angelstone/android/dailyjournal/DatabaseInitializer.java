package com.angelstone.android.dailyjournal;

import android.content.ContentValues;
import android.content.Context;
import android.net.Uri;

public class DatabaseInitializer {
	private static Object[][] entries = new Object[][] {
			new Object[] { PayMethod.CONTENT_URI, PayMethod.COLUMN_NAME, "现金" },
			new Object[] { PayMethod.CONTENT_URI, PayMethod.COLUMN_NAME, "老婆招行" },
			new Object[] { PayMethod.CONTENT_URI, PayMethod.COLUMN_NAME, "老公招行" },
			new Object[] { PayMethod.CONTENT_URI, PayMethod.COLUMN_NAME, "老公中信" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "书" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "伙食费" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "工资" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "超市" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "通讯费" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "交通" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "汽车" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "家用" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "置装费" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "日用品" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "家具和装饰品" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "旅游" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "娱乐" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "医药" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "美容美发" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "交际费" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "礼品" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "物业" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "股票" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "电子用品" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "出差" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "锻炼" },
			new Object[] { Category.CONTENT_URI, Category.COLUMN_NAME, "证件" }, };

	public int getEntryCount() {
		return entries.length;
	}

	public void processEntry(Context context, int entry) {
		if (entry < 0 || entry >= entries.length)
			return;

		Object[] v = entries[entry];

		Uri uri = (Uri) v[0];
		ContentValues values = new ContentValues();

		for (int i = 1; i < v.length; i += 2) {
			values.put((String) v[i], (String) v[i + 1]);
		}

		context.getContentResolver().insert(uri, values);
	}

}
