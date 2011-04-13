package com.angelstone.android.dailyjournal.ui;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.Preference;
import android.preference.Preference.OnPreferenceChangeListener;
import android.preference.PreferenceActivity;

import com.angelstone.android.dailyjournal.R;

public class PreferenceView extends PreferenceActivity implements
		OnPreferenceChangeListener {
	private Preference mProxyEnable = null;
	private Preference mProxyType = null;
	private Preference mProxyHost = null;
	private Preference mProxyPort = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		// Load the preferences from an XML resource
		addPreferencesFromResource(R.xml.journal_preferences);

		SharedPreferences perf = getSharedPreferences(getPackageName()
				+ "_preferences", 0);

		mProxyEnable = findPreference("proxy_enable");
		mProxyEnable.setOnPreferenceChangeListener(this);
		updateSummary(mProxyEnable, perf.getBoolean("proxy_enable", false));

		mProxyType = findPreference("proxy_type");
		mProxyType.setOnPreferenceChangeListener(this);
		updateSummary(mProxyType, perf.getString("proxy_type", "SOCKS"));

		mProxyHost = findPreference("proxy_host");
		mProxyHost.setOnPreferenceChangeListener(this);
		updateSummary(mProxyHost, perf.getString("proxy_host", "localhost"));

		mProxyPort = findPreference("proxy_port");
		mProxyPort.setOnPreferenceChangeListener(this);
		updateSummary(mProxyPort, perf.getString("proxy_port", "18080"));

	}

	@Override
	public boolean onPreferenceChange(Preference preference, Object newValue) {
		return updateSummary(preference, newValue);
	}

	private boolean updateSummary(Preference preference, Object newValue) {
		if (preference == mProxyEnable) {
			if (newValue instanceof Boolean) {
				boolean b = (Boolean) newValue;

				preference
						.setSummary(b ? R.string.summary_proxy_disable_preference
								: R.string.summary_proxy_enable_preference);
				return true;
			}
		}

		if (preference == mProxyType) {
			if (newValue instanceof String) {
				String[] proxy_types = getResources().getStringArray(
						R.array.proxytypes);
				String[] proxy_type_labels = getResources().getStringArray(
						R.array.proxytype_labels);

				for (int i = 0; i < proxy_types.length; i++) {
					if (newValue.equals(proxy_types[i])) {
						preference.setSummary(proxy_type_labels[i]);
						return true;
					}
				}
			}
		}

		if (preference == mProxyHost) {
			if (newValue instanceof String) {
				preference.setSummary((String) newValue);
				return true;
			}
		}

		if (preference == mProxyPort) {
			if (newValue instanceof String) {
				try {
					int port = Integer.parseInt((String) newValue);
					
					if (port > 0) {
						preference.setSummary(String.valueOf(port));
						return true;
					}
				} catch (Throwable t) {

				}
			}
		}
		return false;
	}
}
