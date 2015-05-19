using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database manager.
	/// An editor window for managing the database settings.
	/// If you want to use a different folder for holding your databases 
	/// change the DATABASE_FOLDER_NAME to be your folder.
	/// </summary>
	public class DatabaseManager : EditorWindow
	{
		/// <summary>
		/// The settings, contains all of the settings for database creation.
		/// </summary>
		private static DatabaseSettings _settings;

		/// <summary>
		/// Gets the settings scriptableObject.
		/// </summary>
		/// <value>The settings.</value>
		public static DatabaseSettings settings
		{
			get
			{
				// If _settings is null then 
				// Initalize it
				if(_settings == null)
					InitSettingsDB();

				return _settings;
			}
		}

		/// <summary>
		/// The Folder that all your databases will reside in.
		/// </summary>
		const string DATABASE_FOLDER_NAME = "BZADatabase";

		/// <summary>
		/// Create  a menue to open this editor window using cntrl+shift+m
		/// </summary>
		[MenuItem("BZA/Database/Database Manager %#m")]
		public static void Init()
		{
			DatabaseEditor.InitEditorWindow<DatabaseManager>();
		}

		/// <summary>
		/// Sets the selected database as the database to use.
		/// </summary>
		[MenuItem("Assets/BZA/Set Active/Quality Database")]
		static void SetQualityDBActive()
		{
			settings.itemQualityDatabase = Selection.activeObject.name;
		}

		/// <summary>
		/// Just a fun way to change the settings for the database by going to Edit/Preferences in unity
		/// Displays a new prefrence called BZA Prefernces
		/// </summary>
		[PreferenceItem("BZA Preferences")]
		static void PreferencesGUI()
		{
			settings.databaseFolder = EditorGUILayout.TextField("Database Folder", settings.databaseFolder);
			settings.itemQualityDatabase = EditorGUILayout.TextField("Item Quality Database", settings.itemQualityDatabase);
		}

		/// <summary>
		/// Try's to load the setting scriptable object.
		/// If there is none it will create one.
		/// Uses the const string DATABASE_FOLDER_NAME to load since the settings scriptable object my not yet be loaded.
		/// </summary>
		static void InitSettingsDB()
		{
			// sets a string to the full path of the settings database
			string databaseFullPath = @"Assets/" + DATABASE_FOLDER_NAME + @"/DatabaseSettings.asset";

			// use AssetDatabase to load the database at databaseFullPath
			_settings = AssetDatabase.LoadAssetAtPath<DatabaseSettings>(databaseFullPath);

			// if the database faild to load create it
			if(_settings == null)
			{
				// first make sure that the database folder exists
				// if not then create it.
				if(!AssetDatabase.IsValidFolder(@"Assets/" + DATABASE_FOLDER_NAME))
				{
					AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
				}
				// create A ScriptableObject Instance and set it to the _settings variable
				_settings = ScriptableObject.CreateInstance<DatabaseSettings>();
				// set the database folder name to the one we are using;
				_settings.databaseFolder = DATABASE_FOLDER_NAME;
				// since the database didn't exist create it
				AssetDatabase.CreateAsset(settings, databaseFullPath);
				// save the asset to the assetdatabase
				AssetDatabase.SaveAssets();
				// refresh the assetdatabase
				AssetDatabase.Refresh();
			}
		}

		/// <summary>
		/// Raises the enable event.
		/// </summary>
		void OnEnable()
		{
			// make sure the settings db is initialized
			InitSettingsDB();
		}

		/// <summary>
		/// Raises the GUI event.
		/// </summary>
		void OnGUI()
		{
			// Group the database folder and a lable reminder together on the same row;
			EditorGUILayout.BeginHorizontal();
			//Display a text field for the user to edit the database folder name that they want to use
			_settings.databaseFolder = EditorGUILayout.TextField("Database Folder:", settings.databaseFolder);
			//Display a reminder to change the DATABASE_FOLDER_NAME
			EditorGUILayout.LabelField("Don't forget to change the DATABASE_FOLDER_NAME in DatabaseManager to the one you want to use");
			EditorGUILayout.EndHorizontal();

			//Display a text field for the user to edit the Item Quality database that they want to use
			_settings.itemQualityDatabase = EditorGUILayout.TextField("Item Quality Database:", settings.itemQualityDatabase);
		}
	}
}