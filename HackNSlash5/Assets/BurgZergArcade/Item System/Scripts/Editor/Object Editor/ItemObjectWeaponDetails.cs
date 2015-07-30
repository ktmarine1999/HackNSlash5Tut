using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor
	{
		/// <summary>
		/// The temp weapon to edit weapon that gets created to create a new weapon.
		/// </summary>
		ISWeapon tempWeapon;

		/// <summary>
		/// The show new weapon details.
		/// </summary>
		bool showNewWeaponDetails = false;

		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void WeaponDetails()
		{
			// Create a vertical group Expanding the width and height
			EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
			// Create a horizontal group expanding the width and height 
			EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			switch(displayState)
			{
				case DisplayState.DETAILS:
					if(showNewWeaponDetails)
						DisplayNewWeapon();
					break;
				default:
					break;
			}

			// End Vertical group 
			EditorGUILayout.EndVertical();

			GUILayout.Space(50);

			// Create a horizontal group expanding the width
			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayWeaponButtons();
			// End horizontal group 
			EditorGUILayout.EndHorizontal();

			// End the vertical group 
			EditorGUILayout.EndVertical();
		}//ItemObjectDetails()

		void DisplayNewWeapon()
		{
			if(tempWeapon != null)
			{
				//EditorGUILayout.LabelField("New Weapon");
				tempWeapon.OnGUI();
			}
		}

		void DisplayWeaponButtons()
		{
			// If not showing new weapon details then display the create weapon button
			if(!showNewWeaponDetails)
			{// Create a button to Create a new Weapon
				if(GUILayout.Button("Create Weapon"))
				{
					// Set the temp weapon to a new weapon
					tempWeapon = new ISWeapon();

					// Set the selected index to -1 indicating this weapon needs added to the database when saved
					_weaponSelectedIndex = -1;

					// Set the toggel to true
					showNewWeaponDetails = true;

					// Set the DisplayState to Details
					displayState = DisplayState.DETAILS;
				}//if Create Button
			}//if !showNewWeaponDetails
			// Else show the save and Cancel buttons
			else
			{
				if(GUILayout.Button("Save"))
				{
					if(_weaponSelectedIndex == -1)
						// Add the tempWeapon to the weapons database
						DatabaseManager.weaponDatabase.Add(tempWeapon);
					else
						// Update the selected weapon
						DatabaseManager.weaponDatabase.Replace(_weaponSelectedIndex, tempWeapon);

					// Set the toggel to false
					showNewWeaponDetails = false;

					// Set the DisplayState to NONE
					displayState = DisplayState.NONE;

					// Set tempWeapon to null to make sure the data gets cleared out
					tempWeapon = null;

					// set the focus to be null. Makes it so their is no control focused next time you enter
					GUI.FocusControl(null); 
				}//Save Button

				//If displayState == DisplayState.DETAILS and we are editing a weapon we need a delete button
				if(displayState == DisplayState.DETAILS && _weaponSelectedIndex > -1)
				{
					if(GUILayout.Button("Delete"))
					{
						// Display a Are you sure Dialog and delete the quality to prevent accidental deletion
						if(EditorUtility.DisplayDialog("Delete Weapon",
						                               "Are you sure you want to delete " + DatabaseManager.weaponDatabase.Get(_weaponSelectedIndex).name + "From the database",
						                               "Delete",
						                               "Cancel"))
						{
							// since the user comfirmed it is ok delete the Weapon
							//delete the current selected index put of the database
							DatabaseManager.weaponDatabase.Remove(_weaponSelectedIndex);
							
							// Set the toggel to false
							showNewWeaponDetails = false;
							
							// Set the DisplayState to NONE
							displayState = DisplayState.NONE;
							
							// Set tempWeapon to null to make sure the data gets cleared out
							tempWeapon = null;
							
							// set the focus to be null. Makes it so their is no control focused next time you enter
							GUI.FocusControl(null); 
						}//Delete dialog
					}//Delete Button

				}//displayState.DETAILS
			
				if(GUILayout.Button("Cancel"))
				{
					// Set the toggel to false
					showNewWeaponDetails = false;

					// Set the DisplayState to Details
					displayState = DisplayState.NONE;

					// Set tempWeapon to null to make sure the data gets cleared out
					tempWeapon = null;

					// set the focus to be null. Makes it so their is no control focused next time you enter
					GUI.FocusControl(null); 
				}//Cancle Button
			}//else
		}//DisplayButtons
	}//class
}//namespace