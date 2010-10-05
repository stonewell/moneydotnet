package com.angelstone.android.dailyjournal.ui;

import java.text.NumberFormat;
import java.util.Calendar;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.text.format.DateFormat;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ResourceCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

import com.angelstone.android.dailyjournal.Category;
import com.angelstone.android.dailyjournal.Constants;
import com.angelstone.android.dailyjournal.DatabaseInitializer;
import com.angelstone.android.dailyjournal.DatabaseManager;
import com.angelstone.android.dailyjournal.Journal;
import com.angelstone.android.dailyjournal.PayMethod;
import com.angelstone.android.dailyjournal.R;

public class TodayView extends Activity implements OnClickListener,
		OnItemSelectedListener, OnFocusChangeListener {

	static final int TIME_DIALOG_ID = 0;
	static final int DATE_DIALOG_ID = 1;
	static final int DIALOG_PROGRESS = 2;

	private Calendar mToday = Calendar.getInstance();

	private Cursor mCategoryCursor = null;
	private Cursor mPaymethodCursor = null;
	private Cursor mNameCursor = null;

	private ProgressDialog mProgressDialog;
	private Handler mProgressHandler;

	private int mProgress;
	private int mMaxProgress;

	private Toast mToast = null;

	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener() {

		public void onDateSet(DatePicker view, int year, int monthOfYear,
				int dayOfMonth) {
			mToday.set(year, monthOfYear, dayOfMonth);
			updateDisplay();
		}
	};

	private class NameCursorAdapter extends ResourceCursorAdapter {
		private int mNameIndex = -1;

		public NameCursorAdapter(Context context, int layout, Cursor c) {
			super(context, layout, c, true);

			for (int i = 0; i < c.getColumnCount(); i++)
				Log.e(Constants.TAG, i + "=" + c.getColumnName(i));

			mNameIndex = c.getColumnIndex(Constants.COLUMN_NAME);
		}

		@Override
		public void bindView(View view, Context context, Cursor cursor) {
			if (view instanceof TextView) {
				TextView tv = (TextView) view;
				tv.setText(cursor.getString(mNameIndex));
			}
		}

		@Override
		public boolean hasStableIds() {
			return true;
		}

	};

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.today_table);

		mToday = Calendar.getInstance();

		initData();

		Button btnPick = (Button) findViewById(R.id.pickDate);
		btnPick.setOnClickListener(this);

		prepareCursors();

		Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);
		NameCursorAdapter adapter = new NameCursorAdapter(this,
				android.R.layout.simple_spinner_item, mCategoryCursor);
		adapter
				.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinCategory.setAdapter(adapter);

		Spinner spinPaymethod = (Spinner) findViewById(R.id.spinner_paymethod);
		adapter = new NameCursorAdapter(this, android.R.layout.simple_spinner_item,
				mPaymethodCursor);
		adapter
				.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinPaymethod.setAdapter(adapter);

		Spinner spinName = (Spinner) findViewById(R.id.spinner_name);
		adapter = new NameCursorAdapter(this, android.R.layout.simple_spinner_item,
				mNameCursor);
		adapter
				.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spinName.setAdapter(adapter);
		spinName.setOnItemSelectedListener(this);

		EditText etName = (EditText) findViewById(R.id.edit_name);
		etName.setOnFocusChangeListener(this);

		updateDisplay();
	}

	private void initData() {
		boolean dataInited = DatabaseManager.readSetting(this,
				Constants.OPTION_DATA_INIT);

		if (dataInited)
			return;

		final DatabaseInitializer init = new DatabaseInitializer();
		mMaxProgress = init.getEntryCount();

		showDialog(DIALOG_PROGRESS);

		mProgress = 0;
		mProgressDialog.setProgress(0);

		mProgressHandler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				if (mProgress >= mMaxProgress) {
					mProgressDialog.dismiss();
					DatabaseManager.writeSetting(TodayView.this,
							Constants.OPTION_DATA_INIT, true);
				} else {
					try {
						mProgress++;
						mProgressDialog.incrementProgressBy(1);
						init.processEntry(TodayView.this, mProgress - 1);
					} catch (Exception ex) {
						mProgressDialog.setMessage(ex.getLocalizedMessage());
					}
					mProgressHandler.sendEmptyMessage(0);
				}
			}
		};

		mProgressHandler.sendEmptyMessage(0);
	}

	private void prepareCursors() {
		mCategoryCursor = getContentResolver().query(Category.CONTENT_URI, null,
				null, null, null);
		mPaymethodCursor = getContentResolver().query(PayMethod.CONTENT_URI, null,
				null, null, null);
		mNameCursor = getContentResolver().query(Journal.CONTENT_NAME_URI, null,
				null, null, null);
	}

	private void updateDisplay() {
		TextView date = (TextView) findViewById(R.id.dateDisplay);
		java.text.DateFormat df = DateFormat.getDateFormat(this);
		date.setText(df.format(mToday.getTime()));

		updateTodayTotal();
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.pickDate:
			showDialog(DATE_DIALOG_ID);
			break;
		}

	}

	@Override
	protected Dialog onCreateDialog(int id) {
		switch (id) {
		case DATE_DIALOG_ID:
			return new DatePickerDialog(this, mDateSetListener,
					mToday.get(Calendar.YEAR), mToday.get(Calendar.MONTH),
					mToday.get(Calendar.DATE));
		case DIALOG_PROGRESS:
			mProgressDialog = new ProgressDialog(this);
			mProgressDialog.setIcon(android.R.drawable.ic_dialog_info);
			mProgressDialog.setTitle(R.string.initial_data);
			mProgressDialog.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
			mProgressDialog.setMax(mMaxProgress);
			mProgressDialog.setCancelable(false);
			return mProgressDialog;
		}
		return null;
	}

	@Override
	protected void onPrepareDialog(int id, Dialog dialog) {
		switch (id) {
		case DATE_DIALOG_ID:
			((DatePickerDialog) dialog).updateDate(mToday.get(Calendar.YEAR),
					mToday.get(Calendar.MONTH), mToday.get(Calendar.DATE));

			break;
		}
	}

	@Override
	public boolean onPrepareOptionsMenu(Menu menu) {
		menu.clear();

		menu.add(0, 0, 0, R.string.add_journal).setIcon(
				android.R.drawable.ic_menu_add);
		menu.add(0, 1, 1, R.string.upload).setIcon(
				android.R.drawable.ic_menu_upload);

		return super.onPrepareOptionsMenu(menu);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		return true;
	}

	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case 0: {
			addJournal();
			break;
		}
		default:
			break;
		}
		return true;
	}

	private void addJournal() {
		if (!validateInput()) {
			return;
		}

		ContentValues values = new ContentValues();
		Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);
		Spinner spinPaymethod = (Spinner) findViewById(R.id.spinner_paymethod);

		Cursor c = (Cursor) spinCategory.getSelectedItem();
		int idx = c.getColumnIndex(Constants.COLUMN_NAME);
		values.put(Journal.COLUMN_CATEGORY, c.getString(idx));

		EditText etAmount = (EditText) findViewById(R.id.edit_amount);
		values.put(Journal.COLUMN_AMOUNT,
				Double.parseDouble(etAmount.getText().toString().trim()));

		values.put(Journal.COLUMN_CREATE_DATE, Calendar.getInstance()
				.getTimeInMillis());

		values.put(Journal.COLUMN_PAY_DATE, mToday.getTimeInMillis());

		c = (Cursor) spinPaymethod.getSelectedItem();
		idx = c.getColumnIndex(Constants.COLUMN_NAME);
		values.put(Journal.COLUMN_PAY_METHOD, c.getString(idx));

		ToggleButton tbType = (ToggleButton) findViewById(R.id.toggle_type);
		values.put(Journal.COLUMN_TYPE, tbType.isChecked() ? (int) 1 : (int) 0);

		EditText etName = (EditText) findViewById(R.id.edit_name);
		values.put(Journal.COLUMN_NAME, etName.getText().toString().trim());

		EditText etDesc = (EditText) findViewById(R.id.edit_description);
		values.put(Journal.COLUMN_DESCRIPTION, etDesc.getText().toString());

		getContentResolver().insert(Journal.CONTENT_URI, values);

		mNameCursor.requery();
		etAmount.setText("");

		showToast(R.string.journal_added);
		updateTodayTotal();
	}

	private boolean validateInput() {
		EditText etName = (EditText) findViewById(R.id.edit_name);
		EditText etAmount = (EditText) findViewById(R.id.edit_amount);

		if (TextUtils.isEmpty(etName.getText().toString().trim())) {
			showToast(R.string.name_is_empty);
			return false;
		}

		String amountStr = etAmount.getText().toString().trim();
		if (TextUtils.isEmpty(amountStr)) {
			showToast(R.string.amount_is_empty);
			return false;
		}

		if (Double.parseDouble(amountStr) <= 0) {
			showToast(R.string.amount_must_great_than_zero);
			return false;
		}
		return true;
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position,
			long id) {
		switch (parent.getId()) {
		case R.id.spinner_name: {
			EditText etName = (EditText) findViewById(R.id.edit_name);
			Cursor c = (Cursor) parent.getItemAtPosition(position);
			etName.setText(c.getString(c.getColumnIndex(Journal.COLUMN_NAME)));
			selectMostPopularCategoryForName();
			break;
		}
		default:
			break;
		}

	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {

	}

	@Override
	public void onFocusChange(View v, boolean hasFocus) {
		switch (v.getId()) {
		case R.id.edit_name: {
			if (!hasFocus) {
				selectMostPopularCategoryForName();
			}
			break;
		}
		default:
			break;
		}

	}

	private void selectMostPopularCategoryForName() {
		EditText etName = (EditText) findViewById(R.id.edit_name);
		String name = etName.getText().toString().trim();

		if (TextUtils.isEmpty(name))
			return;

		Cursor c = null, c1 = null;

		try {
			c = getContentResolver().query(Journal.CONTENT_NAME_CATEGORY_URI, null,
					Journal.COLUMN_NAME + "=?1", new String[] { name }, "count desc");

			if (!c.moveToFirst())
				return;

			String category = c.getString(c.getColumnIndex(Journal.COLUMN_CATEGORY));

			Spinner spinCategory = (Spinner) findViewById(R.id.spinner_category);

			c1 = getContentResolver().query(Category.CONTENT_URI,
					new String[] { Category.COLUMN_ID }, Category.COLUMN_NAME + "=?1",
					new String[] { category }, null);

			if (!c1.moveToFirst())
				return;

			int id = c1.getInt(0);

			for (int i = 0; i < spinCategory.getCount(); i++) {
				if (id == spinCategory.getItemIdAtPosition(i)) {
					spinCategory.setSelection(i);
					break;
				}
			}
		} finally {
			if (c != null)
				c.close();
			if (c1 != null)
				c1.close();
		}
	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
		mCategoryCursor.close();
		mPaymethodCursor.close();
		mNameCursor.close();
	}

	@Override
	protected void onResume() {
		super.onResume();
		mCategoryCursor.requery();
		mPaymethodCursor.requery();
		mNameCursor.requery();
	}

	private void showToast(int id) {
		if (mToast != null)
			mToast.cancel();

		mToast = Toast.makeText(this, id, Toast.LENGTH_SHORT);

		mToast.show();
	}

	private void updateTodayTotal() {
		Cursor c = null;
		double cost = 0;
		double income = 0;

		try {
			Calendar zero = Calendar.getInstance();
			zero.setTimeInMillis(mToday.getTimeInMillis());
			zero.set(Calendar.HOUR_OF_DAY, 0);
			zero.set(Calendar.MINUTE, 0);
			zero.set(Calendar.SECOND, 0);

			Calendar end = Calendar.getInstance();
			end.setTimeInMillis(mToday.getTimeInMillis());
			end.set(Calendar.HOUR_OF_DAY, 23);
			end.set(Calendar.MINUTE, 59);
			end.set(Calendar.SECOND, 59);

			c = getContentResolver().query(
					Journal.CONTENT_URI,
					new String[] { Journal.COLUMN_AMOUNT, Journal.COLUMN_TYPE },
					Journal.COLUMN_PAY_DATE + " >= ?1 AND " + Journal.COLUMN_PAY_DATE
							+ " <= ?2",
					new String[] { String.valueOf(zero.getTimeInMillis()),
							String.valueOf(end.getTimeInMillis()) }, null);

			int idxType = c.getColumnIndex(Journal.COLUMN_TYPE);
			int idxAmount = c.getColumnIndex(Journal.COLUMN_AMOUNT);

			while (c.moveToNext()) {
				if (c.getInt(idxType) == 0) {
					cost += c.getDouble(idxAmount);
				} else {
					income += c.getDouble(idxAmount);
				}
			}
		} finally {
			if (c != null)
				c.close();
		}

		NumberFormat nf = NumberFormat.getCurrencyInstance();

		TextView etIncome = (TextView) findViewById(R.id.edit_income_today);
		TextView etCost = (TextView) findViewById(R.id.edit_cost_today);

		etIncome.setText(nf.format(income));
		etCost.setText(nf.format(cost));
	}
}