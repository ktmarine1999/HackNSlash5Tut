using DatabaseManagment.Editor;
using UnityEditor;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectEditor : EditorWindow
    {
        #region States
        /// <summary>
        /// Which Tab we are in
        /// </summary>
        enum TabState
        {
            WEAPON,
            ARMOR,
            CONSUMABLE,
            QUALITY,
            NONE
        }

        TabState tabState;
        #endregion

        #region Weapon
        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDatabase;
        #endregion

        #region Armor
        ISObjectDatabaseType<ISArmorDatabase, ISArmor> armorDatabase;
        #endregion

        #region Consumable
        ISObjectDatabaseType<ISConsumableDatabase, ISConsumable> consumableDatabase;
        #endregion

        #region Consumable
        ISObjectDatabaseType<ISQualityDatabase, ISQuality> qualityDatabase;
        #endregion

        /// <summary>
		/// Create  a menu to open this editor window using cntrl+shift+w
		/// </summary>
		[MenuItem("BZA/Database/Item Object Editor %#i")]
        public static void Init()
        {
            //Initalize this editor window easily with the DatabaseEditor class
            DatabaseEditor.InitEditorWindow<ItemObjectEditor>(new Vector2(800, 600), "Item System");
        }//Init()

        void OnEnable()
        {
            tabState = TabState.QUALITY;

            weaponDatabase = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>(DatabaseManager.weaponDatabase, "Weapon");
            armorDatabase = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>(DatabaseManager.armorDatabase, "Armor");
            consumableDatabase = new ISObjectDatabaseType<ISConsumableDatabase, ISConsumable>(DatabaseManager.consumableDatabase, "Consumable");
            qualityDatabase = new ISObjectDatabaseType<ISQualityDatabase, ISQuality>(DatabaseManager.qualityDatabase, "Quality");
        }

        /// <summary>
        /// Raises the destroy event.
        /// Is called when the editor window is closed
        /// </summary>
        void OnDestroy()
        {
            // Make sure that the database is writen to disk
            EditorUtility.SetDirty(DatabaseManager.weaponDatabase);
            EditorUtility.SetDirty(DatabaseManager.armorDatabase);
            EditorUtility.SetDirty(DatabaseManager.consumableDatabase);
            EditorUtility.SetDirty(DatabaseManager.qualityDatabase);
        }//OnDestroy()

        /// <summary>
        /// Raises the GUI event.
        /// </summary>
        void OnGUI()
        {
            // Display the Top Tab Bar
            TopTabBar();

            // Group the List View and Object Details Horizontaly
            EditorGUILayout.BeginHorizontal();

            switch (tabState)
            {
                case TabState.WEAPON:
                    weaponDatabase.OnGUI();
                    break;
                case TabState.ARMOR:
                    armorDatabase.OnGUI();
                    break;
                case TabState.CONSUMABLE:
                    consumableDatabase.OnGUI();
                    break;
                case TabState.QUALITY:
                    qualityDatabase.OnGUI();
                    break;
                default:
                    EditorGUILayout.LabelField("Default");
                    break;
            }

            EditorGUILayout.EndHorizontal();

            // Display the bottom Status bar
            BottomBar();

            GUIChanged();
        }//OnGUI()

        /// <summary>
        /// If any controls changed the value of the input data, then write the database to disk and make sure that there is a emptyspace for a new item
        /// </summary>
        void GUIChanged()
        {

            // If any controls changed the value of the input data.
            if (GUI.changed)
            {
                // Make sure that the database is writen to disk
                EditorUtility.SetDirty(DatabaseManager.weaponDatabase);
                EditorUtility.SetDirty(DatabaseManager.armorDatabase);
                EditorUtility.SetDirty(DatabaseManager.consumableDatabase);
                EditorUtility.SetDirty(DatabaseManager.qualityDatabase);
            }//if GUI.changed
        }//GUIChanged
    }
}