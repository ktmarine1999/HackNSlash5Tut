using UnityEditor;
using UnityEngine;
using BurgZergArcade.ItemSystem;

namespace DatabaseManagment.Editor
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

        static Databases _databases;

        static Databases databases
        {
            get
            {
                if (_databases == null)
                    _databases = Databases.InitDatabase();

                return _databases;
            }
        }

        #region Item System Quality DB
        /// <summary>
        /// Gets the ISQualityDatabase scriptableObject.
        /// </summary>
        /// <value>The qualityDatabase, contains all of the qualities for item's.</value>
        public static ISQualityDatabase qualityDatabase
        {
            get { return databases.qualityDatabase; }
            set { databases.qualityDatabase = value; }
        }

        public static string[] qualityNames()
        {
            // Initialize the options string to be as big as the db
            string[] options = new string[qualityDatabase.Count];

            //Loop through qdb and add the names to the options 
            for (int cnt = 0; cnt < qualityDatabase.Count; cnt++)
            {
                options[cnt] = qualityDatabase.Get(cnt).name;
            }

            return options;
        }
        #endregion

        #region Item System Euipment Slot DB
        /// <summary>
        /// Gets the ISEquipmentSlotDatabase scriptableObject.
        /// </summary>
        /// <value>The equipmentSlotDatabase, contains all of the equipment slots for item's.</value>
        public static ISEquipmentSlotDatabase equipmentSlotDatabase
        {
            get { return databases.equipmentSlotDatabase; }
            set { databases.equipmentSlotDatabase = value; }
        }
        #endregion

        #region Item System Weapon DB
        /// <summary>
        /// Gets the ISWeaponDatabase scriptableObject.
        /// </summary>
        /// <value>The ISWeaponDatabase, contains all of the ISWeapons to use</value>
        public static ISWeaponDatabase weaponDatabase
        {
            get { return databases.weaponDatabase; }
            set { databases.weaponDatabase = value; }
        }
        #endregion

        #region Item System Armor DB
        /// <summary>
        /// Gets the ISWeaponDatabase scriptableObject.
        /// </summary>
        /// <value>The ISWeaponDatabase, contains all of the ISWeapons to use</value>
        public static ISArmorDatabase armorDatabase
        {
            get { return databases.armorDatabase; }
            set { databases.armorDatabase = value; }
        }
        #endregion

        #region Item System Consumable DB
        /// <summary>
        /// Gets the ISWeaponDatabase scriptableObject.
        /// </summary>
        /// <value>The ISWeaponDatabase, contains all of the ISWeapons to use</value>
        public static ISConsumableDatabase consumableDatabase
        {
            get { return databases.consumableDatabase; }
            set { databases.consumableDatabase = value; }
        }
        #endregion
    }//class
}//namespace