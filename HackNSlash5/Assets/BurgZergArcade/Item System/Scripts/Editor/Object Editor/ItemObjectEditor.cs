using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

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
            ABOUT
        }

        TabState tabState;
        #endregion

        #region Weapon
        ItemObjectCatagory<ISWeapon> weaponItem;
        #endregion

        #region Armor
        ItemObjectCatagory<ISArmor> armorItem;
        #endregion

        #region Consumable
        ItemObjectCatagory<ISConsumable> consumableItem;
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
            tabState = TabState.WEAPON;

            weaponItem = new ItemObjectCatagory<ISWeapon>(DatabaseManager.weaponDatabase, "Weapon");
            armorItem = new ItemObjectCatagory<ISArmor>(DatabaseManager.armorDatabase, "Armor");
            consumableItem = new ItemObjectCatagory<ISConsumable>(DatabaseManager.consumableDatabase, "Consumable");
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
                    // Display the List of the Weapon objects
                    weaponItem.ListView();
                    //ListView<ISWeapon>(DatabaseManager.weaponDatabase, ref tempWeapon, ref _weaponListScrollPos, ref _weaponSelectedIndex, ref showNewWeaponDetails);
                    // Display the Details about the selected weapon
                    //ItemDetails<ISWeapon>(DatabaseManager.weaponDatabase, "Weapon", ref tempWeapon, ref showNewWeaponDetails, ref _weaponSelectedIndex);
                    weaponItem.ItemDetails();
                    break;
                case TabState.ARMOR:
                    // Display the List of the Armor objects
                    armorItem.ListView();
                    //ListView<ISArmor>(DatabaseManager.armorDatabase, ref tempArmor, ref _armorListScrollPos, ref _armorSelectedIndex, ref showNewArmorDetails);
                    // Display the Details about the selected armor
                    //ItemDetails<ISArmor>(DatabaseManager.armorDatabase, "Armor", ref tempArmor, ref showNewArmorDetails, ref _armorSelectedIndex);
                    armorItem.ItemDetails();
                    break;
                case TabState.CONSUMABLE:
                    // Display the List of the Consumable objects
                    consumableItem.ListView();
                    //ListView<ISConsumable>(DatabaseManager.consumableDatabase, ref tempConsumable, ref _consumableListScrollPos, ref _consumableSelectedIndex, ref showNewConsumableDetails);
                    // Display the Details about the selected consumable
                    //ItemDetails<ISConsumable>(DatabaseManager.consumableDatabase, "Consumable", ref tempConsumable, ref showNewConsumableDetails, ref _consumableSelectedIndex);
                    consumableItem.ItemDetails();
                    break;
                case TabState.ABOUT:
                    EditorGUILayout.LabelField("About");
                    AboutView();
                    break;
                default:
                    EditorGUILayout.LabelField("Default");
                    break;
            }

			EditorGUILayout.EndHorizontal();

			// Display the bottom Status bar
			BottomBar();

			//
			GUIChanged();
		}//OnGUI()

		/// <summary>
		/// If any controls changed the value of the input data, then write the database to disk and make sure that there is a emptyspace for a new item
		/// </summary>
		void GUIChanged()
		{

			// If any controls changed the value of the input data.
			if(GUI.changed)
			{
				// write the database to the disk
				EditorUtility.SetDirty(DatabaseManager.weaponDatabase);
                EditorUtility.SetDirty(DatabaseManager.armorDatabase);
                //EditorUtility.SetDirty(DatabaseManager.weaponDatabase);
			}//if GUI.changed
		}//GUIChanged
	}
}