using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor : EditorWindow
	{
		/// <summary>
		/// The asset database this editor is for.
		/// </summary>
		ISWeaponDatabase weaponDatabase;

		/// <summary>
		/// Create  a menue to open this editor window using cntrl+shift+w
		/// </summary>
		[MenuItem("BZA/Database/Item Object Editor %#i")]
		public static void Init()
		{
			//Initalize this editor window easily with the DatabaseEditor class
			DatabaseEditor.InitEditorWindow<ItemObjectEditor>(new Vector2(800, 600), "Item System");
		}//Init()

		/// <summary>
		/// Raises the destroy event.
		/// Is called when the editor window is closed
		/// </summary>
		void OnDestroy()
		{
			// Make sure that the database is writen to disk
			EditorUtility.SetDirty(weaponDatabase);
		}//OnDestroy()

		/// <summary>
		/// Raises the enable event.
		/// </summary>
		void OnEnable()
		{
			// Initialize the asset database we are using
			weaponDatabase = DatabaseEditor.InitDatabase<ISWeaponDatabase>(DatabaseManager.settings.weaponDatabase);
		}

		/// <summary>
		/// Raises the GUI event.
		/// </summary>
		void OnGUI()
		{
			// Display the Top Tab Bar
			TopTabBar();

			// Group the List View and Object Details Horizontaly
			EditorGUILayout.BeginHorizontal();
			// Display the List of the item objects
			ListView();

			// Display the Details about the selected object
			ItemObjectDetails();
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
				EditorUtility.SetDirty(weaponDatabase);
			}//if GUI.changed
		}//GUIChanged
	}
}