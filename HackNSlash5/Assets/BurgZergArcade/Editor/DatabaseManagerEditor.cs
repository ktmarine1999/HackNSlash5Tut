using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database manager.
	/// An editor window for managing the database DatabaseManager.settings.
	/// If you want to use a different folder for holding your databases 
	/// change the DATABASE_FOLDER_NAME to be your folder.
	/// </summary>
	public class DatabaseManagerEditor : EditorWindow
	{
		/// <summary>
		/// Create  a menue to open this editor window using cntrl+shift+m
		/// </summary>
		[MenuItem("BZA/Database/Database Manager %#m")]
		public static void Init()
		{
			DatabaseEditor.InitEditorWindow<DatabaseManagerEditor>();
		}

		/// <summary>
		/// Raises the GUI event.
		/// </summary>
		void OnGUI()
		{
			// Group the database folder and a lable reminder together on the same row;
			EditorGUILayout.BeginHorizontal();

			//Display a text field for the user to edit the database folder name that they want to use
			DatabaseManager.settings.databaseFolder = EditorGUILayout.TextField("Database Folder:", DatabaseManager.settings.databaseFolder);

			//Display a reminder to change the DATABASE_FOLDER_NAME
			EditorGUILayout.LabelField("Don't forget to change the DATABASE_FOLDER_NAME in DatabaseManager to the one you want to use");
			EditorGUILayout.EndHorizontal();
			
			//Display a text field for the user to edit the Item Quality database that they want to use
			DatabaseManager.settings.ISQualityDatabaseName = EditorGUILayout.TextField("Item Quality Database:", DatabaseManager.settings.ISQualityDatabaseName);
			
			//Display a text field for the user to edit the Item Object database that they want to use
			DatabaseManager.settings.ISObjectDatabaseName = EditorGUILayout.TextField("Item Object Database:", DatabaseManager.settings.ISObjectDatabaseName);
			
			//Display a text field for the user to edit the Weapon database that they want to use
			DatabaseManager.settings.ISWeaponDatabaseName = EditorGUILayout.TextField("Weapon Database:", DatabaseManager.settings.ISWeaponDatabaseName);
			
			
			// if the user made changes then write the database to disk
			if(GUI.changed)
				EditorUtility.SetDirty(DatabaseManager.settings);
		}
		
		/// <summary>
		/// Just a fun way to change the DatabaseManager.settings for the database by going to Edit/Preferences in unity
		/// Displays a new prefrence called BZA Prefernces
		/// </summary>
		[PreferenceItem("BZA Preferences")]
		static void PreferencesGUI()
		{
			DatabaseManager.settings.databaseFolder = EditorGUILayout.TextField("Database Folder", DatabaseManager.settings.databaseFolder);
			DatabaseManager.settings.ISQualityDatabaseName = EditorGUILayout.TextField("Item Quality Database", DatabaseManager.settings.ISQualityDatabaseName);
			DatabaseManager.settings.ISObjectDatabaseName = EditorGUILayout.TextField("Item Object Database", DatabaseManager.settings.ISObjectDatabaseName);
			DatabaseManager.settings.ISWeaponDatabaseName = EditorGUILayout.TextField("Weapon Database", DatabaseManager.settings.ISWeaponDatabaseName);
			
			// if the user made changes then write the database to disk
			if(GUI.changed)
				EditorUtility.SetDirty(DatabaseManager.settings);
		}
	}
}