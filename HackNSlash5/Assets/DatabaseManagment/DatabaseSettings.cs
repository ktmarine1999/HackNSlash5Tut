﻿using UnityEngine;

namespace DatabaseManagment.Editor
{
    /// <summary>
    /// Database settings.
    /// All of the database folders and file names to use in editor scripts
    /// </summary>
    [System.Serializable]
    public class DatabaseSettings : ScriptableObject
    {
        /// <summary>
        /// The name of the item system quality database
        /// </summary>
        public string ISQualityDatabaseName = "ISQualityDB";

        /// <summary>
        /// The name of the item  system equipment database
        /// </summary>
        public string ISEquipmentSlotDatabaseName = "ISEquipmentSlotDB";

        /// <summary>
        /// The name of the item object database.
        /// </summary>
        public string ISObjectDatabaseName = "ISObjectDB";

        /// <summary>
        /// The name of the item system weapon database.
        /// </summary>
        public string ISWeaponDatabaseName = "ISWeaponDB";

        /// <summary>
        /// The name of the item system armor database.
        /// </summary>
        public string ISArmorDatabaseName = "ISArmorDB";

        /// <summary>
        /// The name of the item system consumable database.
        /// </summary>
        public string ISConsumableDatabaseName = "ISConsumableDB";
    }
}