using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemQualtiyDatabaseEditor
	{
		/// <summary>
		/// List all of the qualities in the database
		/// </summary>
		private void ListView()
		{
			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
			DisplayQualities();	
			EditorGUILayout.EndScrollView();
		}

		bool fold = true;

		void DisplayQualities()
		{
			if(qualityDatabase.Count > 0)
			{
				for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
				{
					EditorGUILayout.BeginHorizontal("Box");
					selectedItem = qualityDatabase.Get(cnt);

					fold = EditorGUILayout.InspectorTitlebar(fold, selectedItem);

					if(fold)
					{
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
							_selectedIndex = cnt;
						}
					
						// get the returned command
						string commandName = Event.current.commandName;
						// if the command is ObjectSelectorUpdate and the _selectedIndex is == to the current Item
						// then set the selectedItems sprite to the one the user picked
						if(commandName == "ObjectSelectorUpdated" && _selectedIndex == cnt)
						{
							selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
							Repaint();
						}

						EditorGUILayout.BeginVertical();
						// Display a text field for the user to edit the Name of the quality
						selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);

						if(GUILayout.Button("x", GUILayout.Width(30), GUILayout.Height(25)))
						{
							if(EditorUtility.DisplayDialog("Delete Quality",
						                               "Are you sure you want to delete " + selectedItem.Name + "From the database",
						                               "Delete",
						                               "Cancel"))
							{
								qualityDatabase.Remove(cnt);
								return;
							}
						}
						EditorGUILayout.EndVertical();
					}

					if(GUI.changed)
						qualityDatabase.Replace(cnt, selectedItem);

					EditorGUILayout.EndHorizontal();
				}
			}
		}
	}
}