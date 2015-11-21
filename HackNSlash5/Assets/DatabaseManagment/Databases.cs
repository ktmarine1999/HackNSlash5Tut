using BurgZergArcade.ItemSystem;
using UnityEditor;
using UnityEngine;

namespace DatabaseManagment.Editor
{
    [CreateAssetMenu(fileName = "DatabaseToUse", menuName = "Databases To Use", order = 1000)]
    public class Databases : ScriptableObject
    {
        [SerializeField]
        ISEquipmentSlotDatabase _equipmentSlotDatabase;

        [SerializeField]
        ISQualityDatabase _qualityDatabase;

        [SerializeField]
        ISWeaponDatabase _weaponDatabase;

        [SerializeField]
        ISArmorDatabase _armorDatabase;

        [SerializeField]
        ISConsumableDatabase _consumableDatabase;

        public ISEquipmentSlotDatabase equipmentSlotDatabase
        {
            get
            {
                if (_equipmentSlotDatabase == null)
                    _equipmentSlotDatabase = DatabaseEditor.InitDatabase<ISEquipmentSlotDatabase>("ISEquipmentSlotDatabaseAutoCreated");

                return _equipmentSlotDatabase;
            }
            set { _equipmentSlotDatabase = value; }
        }

        public ISQualityDatabase qualityDatabase
        {
            get
            {
                if (_qualityDatabase == null)
                    _qualityDatabase = DatabaseEditor.InitDatabase<ISQualityDatabase>("ISQualityDatabaseAutoCreated");

                return _qualityDatabase;
            }
            set { _qualityDatabase = value; }
        }

        public ISWeaponDatabase weaponDatabase
        {
            get
            {
                if (_weaponDatabase == null)
                    _weaponDatabase = DatabaseEditor.InitDatabase<ISWeaponDatabase>("ISWeaponDatabaseAutoCreated");

                return _weaponDatabase;
            }
            set { _weaponDatabase = value; }
        }

        public ISArmorDatabase armorDatabase
        {
            get
            {
                if (_armorDatabase == null)
                    _armorDatabase = DatabaseEditor.InitDatabase<ISArmorDatabase>("ISArmorDatabaseAutoCreated");

                return _armorDatabase;
            }
            set { _armorDatabase = value; }
        }

        public ISConsumableDatabase consumableDatabase
        {
            get
            {
                if (_consumableDatabase == null)
                    _consumableDatabase = DatabaseEditor.InitDatabase<ISConsumableDatabase>("ISConsumableAutoCreated");

                return _consumableDatabase;
            }
            set
            {
                _consumableDatabase = value;
            }
        }

        public static Databases InitDatabase()
        {
            string databaseName = "DatabasesToUse";

            // set the full path of the scriptable object to load or create
            string databaseFullPath = @"Assets/";
            databaseFullPath += databaseName + ".asset";

            // Load the database that was passed in
            Databases db = AssetDatabase.LoadAssetAtPath<Databases>(databaseFullPath);

            // If no database was loaded then create it
            if (db == null)
            {
                // Log a message that no database was loaded
                Debug.Log("Failed to load " + databaseFullPath);

                // Create a new instance of the database
                db = ScriptableObject.CreateInstance<Databases>();
                // Create a new database at the location given so we can load it the next time
                AssetDatabase.CreateAsset(db, databaseFullPath);
                // Save the database
                AssetDatabase.SaveAssets();
                // Refresh the AssetDatabase
                AssetDatabase.Refresh();
            }

            return db;
        }// Init Database
    }
}
