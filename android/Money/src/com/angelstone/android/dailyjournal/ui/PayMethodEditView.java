package com.angelstone.android.dailyjournal.ui;

import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.PayMethod;

public class PayMethodEditView extends UriEditableListView {

	public PayMethodEditView() {
		super(PayMethod.CONTENT_URI, PayMethod.COLUMN_NAME,
				Journal.COLUMN_PAY_METHOD);
	}
}
