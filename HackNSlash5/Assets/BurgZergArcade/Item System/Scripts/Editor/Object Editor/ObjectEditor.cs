using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ObjectEditor : EditorWindow
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
		/// The scroll position.
		/// Used in ListView when display the List;
		/// </summary>
		Vector2 _scrollPos;
	
		/// <summary>
		/// The index of the selectedItem.
		/// </summary>
		int _selectedIndex = -1;
	
		const int SPRITE_BUTTON_SIZE = 46;

		/// <summary>
		/// Create  a menue to open this editor window using cntrl+shift+w
		/// </summary>
		[MenuItem("BZA/Database/Quality Editor %#i")]
		public static void Init()
		{
			//Initalize this editor window easily with the DatabaseEditor class
			DatabaseEditor.InitEditorWindow<ObjectEditor>(new Vector2(800, 600), "Item System");
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
				// Set the selectedItem to the Current Quality in the database
				selectedItem = objectDatabase.Get(cnt);
				
				// if the selectedItem is null or the Item's name is null or empty 
				// remove the item from the database, this prevents null refrences when using this database
				if(selectedItem == null || string.IsNullOrEmpty(selectedItem.Name))
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
			objectDatabase = DatabaseEditor.InitDatabase<ItemObjectDatabase>(DatabaseManager.settings.itemQualityDatabase);
		
			// set the selected item to a new quality
			selectedItem = new ItemObject();
		
			// add a new quality to the List
			objectDatabase.Add(new ItemObject());
		}//OnEnable()

		/// <summary>
		/// Raises the GUI event.
		/// </summary>
		void OnGUI()
		{
			//if the GUI has been changed then write the database to disk and make sure that there is a emptyspace for a new item
			if(GUI.changed)
			{
				// write the database to the disk
				EditorUtility.SetDirty(objectDatabase);
				
				// if the last item's name in the database is not null or empty add a new one to the end
				if(!string.IsNullOrEmpty(objectDatabase.Get(objectDatabase.Count - 1).Name))
					objectDatabase.Add(new ItemObject());
			}//Gui.changed
		}//OnGUI()
	}
}
