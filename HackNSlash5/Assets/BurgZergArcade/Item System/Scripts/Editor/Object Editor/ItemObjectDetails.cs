using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor
	{
		enum DisplayState
		{
			NONE,
			DETAILS
		}
		;

		/// <summary>
		/// The temp weapon to edit weapon that gets created to create a new weapon.
		/// </summary>
		ISWeapon tempWeapon;

		/// <summary>
		/// The show new weapon details.
		/// </summary>
		bool showNewWeaponDetails = false;

		DisplayState displayState = DisplayState.NONE;

		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void ItemObjectDetails()
		{
			// Create a vertical group Expanding the width and height
			EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
			// Create a horizontal group expanding the width and height 
			EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			EditorGUILayout.LabelField("State: " + displayState);

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
			DisplayButtons();
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

		void DisplayButtons()
		{
			// If not showing new weapon details then display the create weapon button
			if(!showNewWeaponDetails)
			{// Create a button to Create a new Weapon
				if(GUILayout.Button("Create Weapon"))
				{
					// Set the temp weapon to a new weapon
					tempWeapon = new ISWeapon();

					// Set the selected index to -1 indicating this weapon needs added to the database when saved
					_selectedIndex = -1;

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
					if(_selectedIndex = -1)
						// Add the tempWeapon to the weapons database
						DatabaseManager.weaponDatabase.Add(tempWeapon);
					else
						// Update the selected weapon
						DatabaseManager.weaponDatabase.Replace(_selectedIndex, tempWeapon);

					// Set the toggel to true
					showNewWeaponDetails = false;

					// Set the DisplayState to Details
					displayState = DisplayState.NONE;

					// Set tempWeapon to null to make sure the data gets cleared out
					tempWeapon = null;
				}//Save Button
			
				if(GUILayout.Button("Cancel"))
				{
					// Set the toggel to true
					showNewWeaponDetails = false;

					// Set the DisplayState to Details
					displayState = DisplayState.NONE;

					// Set tempWeapon to null to make sure the data gets cleared out
					tempWeapon = null;
				}//Cancle Button
			}//else
		}//DisplayButtons
	}//class
}//namespace