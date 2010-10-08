package com.angelstone.android.dailyjournal.ui;

import com.angelstone.android.dailyjournal.Category;
import com.angelstone.android.dailyjournal.Journal;

public class CategoryEditView extends UriEditableListView {

	public CategoryEditView() {
		super(Category.CONTENT_URI, Category.COLUMN_NAME,
				Journal.COLUMN_CATEGORY);
	}

}
