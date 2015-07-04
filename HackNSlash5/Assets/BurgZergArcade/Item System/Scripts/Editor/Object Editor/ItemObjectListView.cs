using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor
	{
		/// <summary>
		/// The scroll position.
		/// Used in ListView when display the List;
		/// </summary>
		Vector2 _scrollPos = Vector2.zero;

		int _listViewWidth = 200;
		int _listViewButtonWidth = 190;
		int _listViewButtonHeight = 25;

		int _selectedIndex = -1;

		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void ListView()
		{
			// Only display the list if the display state == DisplayState.NONE
			if(displayState != DisplayState.NONE)
				return;

			// Contain the Item Object in a scroll view
			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

			// Display the Weapon Objects in the database
			for(int cnt = 0; cnt < DatabaseManager.weaponDatabase.Count; cnt++)
			{
				if(GUILayout.Button(DatabaseManager.weaponDatabase.Get(cnt).name, "Box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight)))
				{
					//Debug.Log(DatabaseManager.weaponDatabase.Get(cnt).name + " : " + cnt);
					_selectedIndex = cnt;
					//Clone the weapon so we are not working with the copy in the database, in order to save these values have to click save
					tempWeapon = new ISWeapon(DatabaseManager.weaponDatabase.Get(cnt));
					showNewWeaponDetails = true;
					displayState = DisplayState.DETAILS;
				}
			}

			// end the Scroll view
			EditorGUILayout.EndScrollView();
		}//ListView()
	}//class
}//namespace