package com.angelstone.android.dailyjournal.ui;

import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.EditText;
import android.widget.ListAdapter;

import com.angelstone.android.dailyjournal.R;

public abstract class EditableListView extends ListActivity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		registerForContextMenu(getListView());

		setListAdapter(createListAdapter());
	}

	@Override
	public boolean onContextItemSelected(MenuItem item) {
		ContextMenuInfo menuInfo = item.getMenuInfo();
		long childId = 0;

		if (menuInfo instanceof AdapterContextMenuInfo) {
			AdapterContextMenuInfo info = (AdapterContextMenuInfo) menuInfo;
			childId = info.id;
		} else {
			return false;
		}

		switch (item.getItemId()) {
		case 1: {
			editEntry(childId);
			break;
		}
		case 2: {
			deleteEntry(childId);
			break;

		}
		default:
			return super.onContextItemSelected(item);
		}

		return true;
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v,
			ContextMenuInfo menuInfo) {
		super.onCreateContextMenu(menu, v, menuInfo);

		menu.add(0, 1, 1, R.string.menu_edit);
		menu.add(0, 2, 2, R.string.menu_delete);
	}

	private void editEntry(final long childId) {
		LayoutInflater factory = LayoutInflater.from(this);
		final View textEntryView = factory.inflate(
				R.layout.alert_dialog_text_entry, null);

		final EditText entryView = (EditText) textEntryView
				.findViewById(R.id.edit_entry);
		
		entryView.setText(getEditText(childId));

		AlertDialog ad = new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_info)
				.setTitle(R.string.menu_edit)
				.setView(textEntryView)
				.setPositiveButton(android.R.string.ok,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {

								doUpdateEntry(childId, entryView.getText()
										.toString());
							}
						})
				.setNegativeButton(android.R.string.cancel,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {

								/* User clicked cancel so do some stuff */
							}
						}).create();

		ad.show();
	}

	private void deleteEntry(final long childId) {
		AlertDialog ad = new AlertDialog.Builder(this)
				.setIcon(android.R.drawable.ic_dialog_alert)
				.setTitle(android.R.string.dialog_alert_title)
				.setMessage(getConfirmMessage(childId))
				.setPositiveButton(android.R.string.yes,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {
								doDeleteEntry(childId);
							}
						})
				.setNegativeButton(android.R.string.no,
						new DialogInterface.OnClickListener() {
							public void onClick(DialogInterface dialog,
									int whichButton) {
							}
						}).create();
		ad.show();
	}

	protected abstract String getConfirmMessage(long childId);
	protected abstract String getEditText(long childId);
	protected abstract ListAdapter createListAdapter();
	protected abstract void doDeleteEntry(long childId);
	protected abstract void doUpdateEntry(long childId, String entry);
}
