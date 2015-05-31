using UnityEngine;
using UnityEditor;

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
		private void ItemObjectDetails()
		{
			// Create a vertical group Expanding the width and height
			EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

			// Create a horizontal group expanding the width and height 
			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

			//If show new weapon details
			if(showNewWeaponDetails)
				DisplaNewWeapon();

			// End horizontal group 
			EditorGUILayout.EndHorizontal();

			GUILayout.Space(50);

			// Create a horizontal group expanding the width
			EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
			DisplayButtons();
			// End horizontal group 
			EditorGUILayout.EndHorizontal();

			// End the vertical group 
			EditorGUILayout.EndVertical();
		}//ItemObjectDetails()

		void DisplaNewWeapon()
		{
			tempWeapon.OnGUI();
		}

		void DisplayButtons()
		{
			// If not showing new weapon details then display the create weapon button
			if(!showNewWeaponDetails)
			{// Create a button to Create a new Weapon
				if(GUILayout.Button("Create Weapon"))
				{
					// Set the toggel to true
					showNewWeaponDetails = true;
					// Set the temp weapon to a new weapon
					tempWeapon = new ISWeapon();
				}//if Create Button
			}//if !showNewWeaponDetails
			// Else show the save and Cancel buttons
			else
			{
				if(GUILayout.Button("Save"))
				{
					// Set the toggel to true
					showNewWeaponDetails = false;
				}//Save Button
			
				if(GUILayout.Button("Cancel"))
				{
					// Set the toggel to true
					showNewWeaponDetails = false;
				}//Cancle Button
			}//else
		}//DisplayButtons
	}//class
}//namespace