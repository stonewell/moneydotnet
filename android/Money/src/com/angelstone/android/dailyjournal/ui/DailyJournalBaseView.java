package com.angelstone.android.dailyjournal.ui;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.content.pm.PackageInfo;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.angelstone.android.dailyjournal.R;
import com.angelstone.android.ui.ActivityLogActivity;

public abstract class DailyJournalBaseView extends Activity {
	private Toast mToast = null;
	private int mOptionMenuStartPos = 0;

	private static final int[][] OPTION_MENUS = new int[][] {
			new int[] { R.string.view_logs,
					android.R.drawable.ic_menu_info_details },
			new int[] { R.string.preference,
					android.R.drawable.ic_menu_preferences },
			new int[] { R.string.help, android.R.drawable.ic_menu_help }, };

	public DailyJournalBaseView(int optionMenuStartPos) {
		mOptionMenuStartPos = optionMenuStartPos;
	}

	public DailyJournalBaseView() {
		this(0);
	}

	@Override
	public boolean onPrepareOptionsMenu(Menu menu) {
		if (mOptionMenuStartPos == 0)
			menu.clear();

		createMenus(menu, mOptionMenuStartPos, OPTION_MENUS);

		return super.onPrepareOptionsMenu(menu);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		return true;
	}

	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId() - mOptionMenuStartPos) {
		case 0: {
			Intent intent = new Intent();
			intent.setClass(this, ActivityLogActivity.class);
			startActivity(intent);
			break;
		}
		case 1: {
			Intent intent = new Intent();
			intent.setClass(this, PreferenceView.class);
			startActivity(intent);
			break;
		}
		case 2: {
			showAbout();
			break;
		}
		default:
			return false;
		}
		return true;
	}

	protected void createMenus(Menu menu, int beginPos, int[][] items) {
		for (int i = 0; i < items.length; i++) {
			menu.add(0, beginPos + i, beginPos + i, items[i][0]).setIcon(
					items[i][1]);
		}
	}

	protected void showToast(final int id) {
		runOnUiThread(new Runnable() {

			@Override
			public void run() {
				if (mToast != null)
					mToast.cancel();

				mToast = Toast.makeText(DailyJournalBaseView.this, id,
						Toast.LENGTH_SHORT);

				mToast.show();
			}
		});
	}

	protected void showAbout() {
		// Inflate the about message contents
		View messageView = getLayoutInflater().inflate(R.layout.about, null,
				false);

		// When linking text, force to always use default color. This works
		// around a pressed color state bug.
		TextView textView = (TextView) messageView
				.findViewById(R.id.about_credits);
		int defaultColor = textView.getTextColors().getDefaultColor();
		textView.setTextColor(defaultColor);

		AlertDialog.Builder builder = new AlertDialog.Builder(this);
		builder.setIcon(R.drawable.icon);

		String version = "";
		try {
			PackageInfo info = getPackageManager().getPackageInfo(
					getPackageName(), 0);
			version = info.versionName;
		} catch (Exception e) {

		}
		builder.setTitle(getString(R.string.app_name) + " " + version);
		builder.setView(messageView);
		builder.create();
		builder.show();
	}
}
