using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor : EditorWindow
	{
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

        int _listViewWidth = 200;
        int _listViewButtonWidth = 190;
        int _listViewButtonHeight = 25;

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
                    EditorGUILayout.LabelField("Weapon");
                    // Display the List of the Weapon objects
                    WeaponListView();
                    // Display the Details about the selected weapon
                    WeaponDetails();
                    break;
                case TabState.ARMOR:
                    EditorGUILayout.LabelField("Armor");
                    // Display the List of the Armor objects
                    ArmorListView();
                    // Display the Details about the selected armor
                    ArmorDetails();
                    break;
                case TabState.CONSUMABLE:
                    EditorGUILayout.LabelField("Consumable");
                    // Display the List of the Consumable objects
                    //ConsumableListView();
                    // Display the Details about the selected consumable
                    //ConsumableDetails();
                    break;
                case TabState.ABOUT:
                    EditorGUILayout.LabelField("About");
                    //AboutView();
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
			}//if GUI.changed
		}//GUIChanged
	}
}