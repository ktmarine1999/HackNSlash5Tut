using UnityEditor;
using UnityEngine;
using BurgZergArcade.ItemSystem;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database manager.
	/// An editor window for managing the database settings.
	/// If you want to use a different folder for holding your databases 
	/// change the DATABASE_FOLDER_NAME to be your folder.
	/// </summary>
	public partial class DatabaseManager
	{
		/// <summary>
		/// The Folder that all your databases will reside in.
		/// </summary>
		public const string DATABASE_FOLDER_NAME = "BZADatabase";

		#region Settings DB
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
				// write the database to disk
				EditorUtility.SetDirty(_settings);
				// since the database didn't exist create it
				AssetDatabase.CreateAsset(settings, databaseFullPath);
				// save the asset to the assetdatabase
				AssetDatabase.SaveAssets();
				// refresh the assetdatabase
				AssetDatabase.Refresh();
			}//if_settings == null
		}//InitSettingDB
		#endregion

		#region Item System Quality DB
		/// <summary>
		/// The qualityDatabase, contains all of the qualities for item's.
		/// </summary>
		private static ISQualityDatabase _qualityDatabase;
		
		/// <summary>
		/// Gets the ISQualityDatabase scriptableObject.
		/// </summary>
		/// <value>The qualityDatabase, contains all of the qualities for item's.</value>
		public static ISQualityDatabase qualityDatabase
		{
			get
			{
				// If _settings is null then 
				// Initalize it
				if(_qualityDatabase == null)
					_qualityDatabase = DatabaseEditor.InitDatabase<ISQualityDatabase>(DatabaseManager.settings.ISQualityDatabaseName);
				
				return _qualityDatabase;
			}
		}

		public static string[] qualityNames()
		{
			// Initialize the options string to be as big as the db
			string[] options = new string[qualityDatabase.Count];
			
			//Loop through qdb and add the names to the options 
			for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
			{
				options[cnt] = qualityDatabase.Get(cnt).name;
			}
			
			return options;
		}
		#endregion

		#region Item System Euipment Slot DB
		/// <summary>
		/// The equipmentSlotDatabase, contains all of the equipment slot's for item's.
		/// </summary>
		private static ISEquipmentSlotDatabase _equipmentSlotDatabase;
		
		/// <summary>
		/// Gets the ISEquipmentSlotDatabase scriptableObject.
		/// </summary>
		/// <value>The equipmentSlotDatabase, contains all of the equipment slots for item's.</value>
		public static ISEquipmentSlotDatabase equipmentSlotDatabase
		{
			get
			{
				// If _settings is null then 
				// Initalize it
				if(_equipmentSlotDatabase == null)
					_equipmentSlotDatabase = DatabaseEditor.InitDatabase<ISEquipmentSlotDatabase>(DatabaseManager.settings.ISEquipmentSlotDatabaseName);
				
				return _equipmentSlotDatabase;
			}
		}
		#endregion

		#region Item System Object DB
		/// <summary>
		/// The ISObjectDatabase, contains all of the ISObjects to use.
		/// </summary>
		private static ISObjectDatabase _objectDatabase;
		
		/// <summary>
		/// Gets the ISObjectDatabase scriptableObject.
		/// </summary>
		/// <value>The ISObjectDatabase, contains all of the ISObjects to use</value>
		public static ISObjectDatabase objectDatabase
		{
			get
			{
				// If _settings is null then 
				// Initalize it
				if(_objectDatabase == null)
					_objectDatabase = DatabaseEditor.InitDatabase<ISObjectDatabase>(DatabaseManager.settings.ISObjectDatabaseName);
				
				return _objectDatabase;
			}
		}
		#endregion

		#region Item System Weapon DB
		/// <summary>
		/// The ISWeaponDatabase, contains all of the ISWeapons to use.
		/// </summary>
		private static ISWeaponDatabase _weaponDatabase;
		
		/// <summary>
		/// Gets the ISWeaponDatabase scriptableObject.
		/// </summary>
		/// <value>The ISWeaponDatabase, contains all of the ISWeapons to use</value>
		public static ISWeaponDatabase weaponDatabase
		{
			get
			{
				// If _settings is null then 
				// Initalize it
				if(_weaponDatabase == null)
					_weaponDatabase = DatabaseEditor.InitDatabase<ISWeaponDatabase>(DatabaseManager.settings.ISWeaponDatabaseName);
				
				return _weaponDatabase;
			}
		}
		#endregion

        #region Item System Armor DB
        /// <summary>
        /// The ISWeaponDatabase, contains all of the ISWeapons to use.
        /// </summary>
        private static ISArmorDatabase _armorDatabase;

        /// <summary>
        /// Gets the ISWeaponDatabase scriptableObject.
        /// </summary>
        /// <value>The ISWeaponDatabase, contains all of the ISWeapons to use</value>
        public static ISArmorDatabase armorDatabase
        {
            get
            {
                // If _settings is null then 
                // Initalize it
                if (_armorDatabase == null)
                    _armorDatabase = DatabaseEditor.InitDatabase<ISArmorDatabase>(DatabaseManager.settings.ISArmorDatabaseName);

                return _armorDatabase;
            }
        }
        #endregion

        #region Item System Consumable DB
        /// <summary>
        /// The ISWeaponDatabase, contains all of the ISWeapons to use.
        /// </summary>
        private static ISConsumableDatabase _consumableDatabase;

        /// <summary>
        /// Gets the ISWeaponDatabase scriptableObject.
        /// </summary>
        /// <value>The ISWeaponDatabase, contains all of the ISWeapons to use</value>
        public static ISConsumableDatabase consumableDatabase
        {
            get
            {
                // If _settings is null then 
                // Initalize it
                if (_consumableDatabase == null)
                    _consumableDatabase = DatabaseEditor.InitDatabase<ISConsumableDatabase>(DatabaseManager.settings.ISConsumableDatabaseName);

                return _consumableDatabase;
            }
        }
        #endregion
	}//class
}//namespace