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

        /// <summary>
        /// What state to display
        /// </summary>
        enum DisplayState
        {
            NONE,
            DETAILS
        }

        /// <summary>
        /// What to display
        /// </summary>
        DisplayState displayState;
        #endregion

        #region Weapon
        /// <summary>
        /// The temp weapon to edit weapon that gets created to create a new weapon.
        /// </summary>
        ISWeapon tempWeapon;

        /// <summary>
        /// The scroll position.
        /// Used in ListView when display the List;
        /// </summary>
        Vector2 _weaponListScrollPos = Vector2.zero;

        /// <summary>
        /// The selected weapon index
        /// </summary>
        int _weaponSelectedIndex = -1;

        /// <summary>
        /// The show new weapon details.
        /// </summary>
        bool showNewWeaponDetails = false;
        #endregion

        #region Armor
        /// <summary>
        /// The temp armor to edit armor that gets created to create a new armor.
        /// </summary>
        ISArmor tempArmor;

        /// <summary>
        /// The scroll position.
        /// Used in ListView when display the List;
        /// </summary>
        Vector2 _armorListScrollPos = Vector2.zero;

        /// <summary>
        /// The selected armor index
        /// </summary>
        int _armorSelectedIndex = -1;

        /// <summary>
        /// The show new armor details.
        /// </summary>
        bool showNewArmorDetails = false;
        #endregion

        #region Consumable
        /// <summary>
        /// The temp Consumable to edit Consumable that gets created to create a new Consumable.
        /// </summary>
        ISConsumable tempConsumable;

        /// <summary>
        /// The scroll position.
        /// Used in ListView when display the List;
        /// </summary>
        Vector2 _consumableListScrollPos = Vector2.zero;

        /// <summary>
        /// The selected armor index
        /// </summary>
        int _consumableSelectedIndex = -1;

        /// <summary>
        /// The show new Consumable details.
        /// </summary>
        bool showNewConsumableDetails = false;
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
            displayState = DisplayState.NONE;
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
            //EditorUtility.SetDirty(DatabaseManager.weaponDatabase);
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
                    ListView<ISWeapon>(DatabaseManager.weaponDatabase, ref tempWeapon, ref _weaponListScrollPos, ref _weaponSelectedIndex, ref showNewWeaponDetails);
                    // Display the Details about the selected weapon
                    ItemDetails<ISWeapon>(DatabaseManager.weaponDatabase, "Weapon", ref tempWeapon, ref showNewWeaponDetails, ref _weaponSelectedIndex);
                    break;
                case TabState.ARMOR:
                    EditorGUILayout.LabelField("Armor");
                    // Display the List of the Armor objects
                    ListView<ISArmor>(DatabaseManager.armorDatabase, ref tempArmor, ref _armorListScrollPos, ref _armorSelectedIndex, ref showNewArmorDetails);
                    // Display the Details about the selected armor
                    ItemDetails<ISArmor>(DatabaseManager.armorDatabase, "Armor", ref tempArmor, ref showNewArmorDetails, ref _armorSelectedIndex);
                    break;
                case TabState.CONSUMABLE:
                    EditorGUILayout.LabelField("Consumable");
                    // Display the List of the Consumable objects
                    ListView<ISConsumable>(DatabaseManager.consumableDatabase, ref tempConsumable, ref _consumableListScrollPos, ref _consumableSelectedIndex, ref showNewConsumableDetails);
                    // Display the Details about the selected consumable
                    ItemDetails<ISConsumable>(DatabaseManager.consumableDatabase, "Consumable", ref tempConsumable, ref showNewConsumableDetails, ref _consumableSelectedIndex);
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