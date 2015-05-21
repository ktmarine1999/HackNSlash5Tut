using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemQualtiyDatabaseEditor : EditorWindow
	{
		/// <summary>
		/// The asset database this editor is for.
		/// </summary>
		ItemQualityDatabase qualityDatabase;

		/// <summary>
		/// The selected item.
		/// </summary>
		ItemQuality selectedItem;

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
		/// Create  a menue to open this editor window using cntrl+shift+i
		/// </summary>
		[MenuItem("BZA/Database/Quality Editor %#i")]
		public static void Init()
		{
			//Initalize this editor window easily with the DatabaseEditor class
			DatabaseEditor.InitEditorWindow<ItemQualtiyDatabaseEditor>();
		}//Init()

		/// <summary>
		/// Raises the enable event.
		/// </summary>
		void OnEnable()
		{
			// Initialize the asset database we are using
			qualityDatabase = DatabaseEditor.InitDatabase<ItemQualityDatabase>(DatabaseManager.settings.itemQualityDatabase);

			// set the selected item to a new quality
			selectedItem = new ItemQuality();

			// add a new quality to the List
			qualityDatabase.Add(new ItemQuality());
		}//OnEnable()

		/// <summary>
		/// Raises the destroy event.
		/// Is called when the editor window is closed
		/// </summary>
		void OnDestroy()
		{
			// For every item in the database
			for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
			{
				// Set the selectedItem to the Current Quality in the database
				selectedItem = qualityDatabase.Get(cnt);

				// if the selectedItem is null or the Item's name is null or empty 
				// remove the item from the database, this prevents null refrences when using this database
				if(selectedItem == null || string.IsNullOrEmpty(selectedItem.Name))
					qualityDatabase.Remove(cnt);

			}//for loop

			// Make sure that the database is writen to disk
			EditorUtility.SetDirty(qualityDatabase);
		}//OnDestroy()

		/// <summary>
		/// Raises the GUI event.
		/// </summary>
		void OnGUI()
		{
			// Display the Quality database in a list
			ListView();
			//AddQualityToDatabase();

			//Contain the bottom bar in a box style at the end
			EditorGUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			BottomBar();
			// End the bottom bar group
			EditorGUILayout.EndHorizontal();

			//if the GUI has been changed then write the database to disk and make sure that there is a emptyspace for a new item
			if(GUI.changed)
			{
				// write the database to the disk
				EditorUtility.SetDirty(qualityDatabase);

				// if the last item's name in the database is not null or empty add a new one to the end
				if(!string.IsNullOrEmpty(qualityDatabase.Get(qualityDatabase.Count - 1).Name))
					qualityDatabase.Add(new ItemQuality());
			}//Gui.changed

		}//OnGUI()

		/// <summary>
		/// The bottom bar.
		/// Contains the count
		/// </summary>
		void BottomBar()
		{
			//Display a label that tell's us how many items we have in the quality database
			EditorGUILayout.LabelField("Qualities: " + qualityDatabase.Count - 1);
		}//BottomBar()
	}//class
}//namespace