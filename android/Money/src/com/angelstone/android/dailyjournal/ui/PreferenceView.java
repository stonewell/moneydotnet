package com.angelstone.android.dailyjournal.ui;

import android.os.Bundle;
import android.preference.PreferenceActivity;

import com.angelstone.android.dailyjournal.R;

public class PreferenceView extends PreferenceActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        // Load the preferences from an XML resource
        addPreferencesFromResource(R.xml.journal_preferences);
    }
}
