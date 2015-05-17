using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.Editor
{
	public class DatabasePrefs
	{

		// Have we loaded the prefs yet
		private static bool prefsLoaded = false;
	
		// The Preferences
		public static string databaseFolder = "BZADatabase";

		public static string itemQualityDatabase = "ItemQualityDB";
	
		// Add preferences section named "My Preferences" to the Preferences Window;
		[PreferenceItem("BZA Preferences")]
		static void PreferencesGUI()
		{
			// Load the preferences
			if(!prefsLoaded)
			{
				EditorPrefs.GetString("DatabaseFolder");
				prefsLoaded = true;
			}
		
			// Preferences GUI
			databaseFolder = EditorGUILayout.TextField("Database Folder", databaseFolder);
			itemQualityDatabase = EditorGUILayout.TextField("Item Quality Database", itemQualityDatabase);
		
			// Save the preferences
			if(GUI.changed)
			{
				EditorPrefs.SetString("DatabaseFolder", databaseFolder);
				EditorPrefs.SetString("ItemQualityDB", itemQualityDatabase);
			}
		}

		[MenuItem("Assets/BZA/Set Active/Quality Database")]
		static void SetQualityDBActive()
		{
			DatabasePrefs.itemQualityDatabase = Selection.activeObject.name;
			EditorPrefs.SetString("ItemQualityDB", DatabasePrefs.itemQualityDatabase);
		}
	}
}