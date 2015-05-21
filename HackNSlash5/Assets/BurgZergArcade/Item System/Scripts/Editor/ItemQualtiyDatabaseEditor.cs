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
		}

		/// <summary>
		/// Raises the enable event.
		/// </summary>
		void OnEnable()
		{
			// Initialize the asset database we are using
			qualityDatabase = DatabaseEditor.InitDatabase<ItemQualityDatabase>(DatabaseManager.settings.itemQualityDatabase);

			// set the selected item to a new quality
			selectedItem = new ItemQuality();
		}

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

			//if the GUI has been changed then write the database to disk
			if(GUI.changed)
				EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// The bottom bar.
		/// Contains the count and an add button
		/// </summary>
		void BottomBar()
		{
			//Display a label that tell's us how many items we have in the quality database
			EditorGUILayout.LabelField("Qualities: " + qualityDatabase.Count);

			//Display an add button so the user can add another a new quality to the list
			if(GUILayout.Button("Add"))
			{
				// add a new quality to the List
				qualityDatabase.Add(new ItemQuality());
			}
		}

		/// <summary>
		/// Adds the quality to database.
		/// </summary>
		void AddQualityToDatabase()
		{
			// Display a text field for the user to edit the Name of the quality
			selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);

			// If the item has a sprite then set the selectedTexture to the selectedItem's sprite texture
			if(selectedItem.Icon)
				selectedTexture = selectedItem.Icon.texture;
			// else set the selectedTexture to null
			else
				selectedTexture = null;

			// Display a button to change the selected items sprite, use the selectedTexture as the bakground image for the button
			if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
			{
				int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
				EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlerID);
			}

			// get the returned command
			string commandName = Event.current.commandName;
			// if the command is ObjectSelectorUpdate then set the selectedItems sprite to the one the user picked
			if(commandName == "ObjectSelectorUpdated")
			{
				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
				Repaint();
			}

			// Display a button so the user can save the Quality to the Database
			if(GUILayout.Button("Save"))
			{
				// if the selectedItem is null 
				// or the Item's name is null or empty 
				// no need to do anything return
				// this prevents null refrences when using this database
				if(selectedItem == null || string.IsNullOrEmpty(selectedItem.Name))
					return;

				// add the selectedItem to the database
				qualityDatabase.Add(selectedItem);

				// set the selectedItem to a new Quality
				selectedItem = new ItemQuality();
			}
		}
	}
}