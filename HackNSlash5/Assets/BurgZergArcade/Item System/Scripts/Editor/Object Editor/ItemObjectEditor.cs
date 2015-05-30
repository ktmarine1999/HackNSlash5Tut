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
		ItemObjectDatabase objectDatabase;
	
		/// <summary>
		/// The selected item.
		/// </summary>
		ItemObject selectedItem;
	
		/// <summary>
		/// The selected item's texture.
		/// </summary>
		Texture2D selectedTexture;
	
		/// <summary>
		/// The index of the selectedItem.
		/// </summary>
		int _selectedIndex = -1;
	
		const int SPRITE_BUTTON_SIZE = 46;

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
			// For every item in the database
			for(int cnt = 0; cnt < objectDatabase.Count; cnt++)
			{
				// Set the selectedItem to the Current Item Object in the database
				selectedItem = objectDatabase.Get(cnt);
				
				// if the selectedItem is null or the Item's name is not valid
				// remove the item from the database, this prevents null refrences when using this database
				if(selectedItem == null || !NameValid(selectedItem.Name))
					objectDatabase.Remove(cnt);
				
			}//for loop
			
			// Make sure that the database is writen to disk
			EditorUtility.SetDirty(objectDatabase);
		}//OnDestroy()

		/// <summary>
		/// Raises the enable event.
		/// </summary>
		void OnEnable()
		{
			// Initialize the asset database we are using
			objectDatabase = DatabaseEditor.InitDatabase<ItemObjectDatabase>(DatabaseManager.settings.itemObjectDatabase);
		
			// set the selected item to a new Item Object
			selectedItem = new ItemObject();
		
			// add a new Item Object to the List
			objectDatabase.Add(new ItemObject());
		}//OnEnable()

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
				EditorUtility.SetDirty(objectDatabase);
				
				// if the last item's name in the database is valid then add a new one to the end
				if(NameValid(objectDatabase.Get(objectDatabase.Count - 1).Name))
					objectDatabase.Add(new ItemObject());
			}//if GUI.changed
		}//GUIChanged

		/// <summary>
		/// Is the name valid.
		/// </summary>
		/// <returns><c>true</c>, if name was valid, <c>false</c> otherwise.</returns>
		/// <param name="itemName">Item name.</param>
		bool NameValid(string itemName)
		{
			// If the item's name is null or empty the name is not a valid name
			if(string.IsNullOrEmpty(itemName))
			{
				return false;
			}
			// else if the item's name == new item the name is not a valid name
			else if(itemName.ToLower() == "new item")
			{
				return false;
			}
			// else the name is valid
			else
			{
				return true;
			}
		}
	}
}