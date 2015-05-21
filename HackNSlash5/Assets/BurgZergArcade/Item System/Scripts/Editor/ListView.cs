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
			//Contain the Qualities in a scroll view
			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandHeight(true));
			// Display the Qualities in the database
			DisplayQualities();	
			// end the Scroll view
			EditorGUILayout.EndScrollView();
		}

		/// <summary>
		/// Displays the qualities.
		/// </summary>
		void DisplayQualities()
		{
			// if the list does not contain any items then return
			if(!(qualityDatabase.Count > 0))
				return;

			// For every item in the database
			for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
			{
				// Contain each Item in its own Box style group
				EditorGUILayout.BeginHorizontal("Box");

				// Set the selectedItem to the Current Quality in the database
				selectedItem = qualityDatabase.Get(cnt);

				// Display and update the quality icon
				QualityIcon(cnt);

				// Contain the name and delete button together verticaly
				EditorGUILayout.BeginVertical();

				// Display a text field for the user to edit the Name of the quality
				selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);

				// Display Delete quality and reset cnt to keep it in range of the list
				cnt = DeleteCurrentQuality(cnt);

				//End the name and delete button group
				EditorGUILayout.EndVertical();

				// end the current quality Group
				EditorGUILayout.EndHorizontal();
			}//for loop
		}//DisplayQualities

		/// <summary>
		/// Display and update the Quality icon.
		/// </summary>
		/// <param name="cnt">Count.</param>
		void QualityIcon(int currentIndex)
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
				// Display an item picker so the user can select what sprite to use
				int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
				//Used for the ObjectPicker
				EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlerID);
				// Capture the current Index so we can update the selected texture and sprite for only the curent quality
				_selectedIndex = currentIndex;
			}//Sprite Button

			// get the returned command
			string commandName = Event.current.commandName;
			// if the selected object was changed for the current Item
			// then set the selectedItems sprite to the one the user picked
			if(commandName == "ObjectSelectorUpdated" && _selectedIndex == currentIndex)
			{
				// Set the selectedItem's Sprite to the on the user picked 
				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
				// Repaint the window so the objects are Displayed with their updated values
				Repaint();
			}
			//selected object was changed for the current Item
			// if the user closed the object picker window
			if(commandName == "ObjectSelectorClosed ")
			{
				// reset the _selectedIndex to -1
				_selectedIndex = -1;
			}//the user closed the object picker window
		}//QualityIcon

		/// <summary>
		/// Deletes the current quality.
		/// </summary>
		/// <returns>if deleted The index of the quality before this one was deleted else the index passed in</returns>
		int DeleteCurrentQuality(int currentIndex)
		{
			// Display a button to delete the quality from the database
			if(GUILayout.Button("x", GUILayout.Width(30), GUILayout.Height(25)))
			{
				// Display a Are you sure Dialog and delete the quality to prevent accidental deletion
				if(EditorUtility.DisplayDialog("Delete Quality",
				                               "Are you sure you want to delete " + selectedItem.Name + "From the database",
				                               "Delete",
				                               "Cancel"))
				{
					// since the user comfirmed it is ok delete the quality
					qualityDatabase.Remove(currentIndex);
					// return the previous index since this on no longer exists
					return currentIndex - 1;
				}//Delete dialog
			}//Delete Button

			// The user did not delete the current quality so retrun the current index
			return currentIndex;
		}// DeleteCurrentQuality
	}//class
}//Nnamespace