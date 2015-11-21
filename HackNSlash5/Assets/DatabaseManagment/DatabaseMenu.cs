#if UNITY_EDITOR
using BurgZergArcade.ItemSystem;
using UnityEditor;
#endif
using UnityEngine;

namespace DatabaseManagment.Editor
{
    /// <summary>
    /// Database editor.
    /// A helper class use to load editor windows and scriptable objects.
    /// </summary>
    public static partial class DatabaseEditor
    {
#if UNITY_EDITOR
        #region Create Databases
        [MenuItem("Assets/BZA/Create/Item System/Quality Database")]
        public static void CreateISQualityDatabase()
        {
            CreateAsset<BurgZergArcade.ItemSystem.ISQualityDatabase>();
        }

        [MenuItem("Assets/BZA/Create/Item System/Equipment Slot Database")]
        public static void CreateISEquipmentSlotDatabase()
        {
            CreateAsset<BurgZergArcade.ItemSystem.ISEquipmentSlotDatabase>();
        }

        [MenuItem("Assets/BZA/Create/Item System/Weapon Database")]
        public static void CreateWeaponDatabase()
        {
            CreateAsset<BurgZergArcade.ItemSystem.ISWeaponDatabase>();
        }

        [MenuItem("Assets/BZA/Create/Item System/Armor Database")]
        public static void CreateArmorDatabase()
        {
            CreateAsset<BurgZergArcade.ItemSystem.ISArmorDatabase>();
        }

        [MenuItem("Assets/BZA/Create/Item System/Consumable Database")]
        public static void CreateConsumableDatabase()
        {
            CreateAsset<BurgZergArcade.ItemSystem.ISConsumableDatabase>();
        }


        /// <summary>
        /// Create new asset from <see cref="ScriptableObject"/> type with unique name at
        /// selected folder in project window. Asset creation can be cancelled by pressing
        /// escape key when asset is initially being named.
        /// </summary>
        /// <typeparam name="T">Type of scriptable object.</typeparam>
        public static void CreateAsset<T>() where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            ProjectWindowUtil.CreateAsset(asset, "New " + typeof(T).Name + ".asset");
        }
        #endregion

        /// <summary>
        /// Sets the selected database as the database to use.
        /// </summary>
        [MenuItem("Assets/BZA/Set as Database To Use")]
        static void SetISDBActive()
        {
            if (Selection.activeObject is ISQualityDatabase)
                DatabaseManager.qualityDatabase = Selection.activeObject as ISQualityDatabase;
            if (Selection.activeObject is ISEquipmentSlotDatabase)
                DatabaseManager.equipmentSlotDatabase = Selection.activeObject as ISEquipmentSlotDatabase;
            if (Selection.activeObject is ISWeaponDatabase)
                DatabaseManager.weaponDatabase = Selection.activeObject as ISWeaponDatabase;
            if (Selection.activeObject is ISArmorDatabase)
                DatabaseManager.armorDatabase = Selection.activeObject as ISArmorDatabase;
            if (Selection.activeObject is ISConsumableDatabase)
                DatabaseManager.consumableDatabase = Selection.activeObject as ISConsumableDatabase;
        }
#endif
    }//class
}//namespace