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

		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void ListView()
		{
			// Contain the Item Object in a scroll view
			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

			// Display the Weapon Objects in the database
			for(int cnt = 0; cnt < DatabaseManager.weaponDatabase.Count; cnt++)
			{
				if(GUILayout.Button(DatabaseManager.weaponDatabase.Get(cnt).name, "Box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight)))
				{

				}
			}

			// end the Scroll view
			EditorGUILayout.EndScrollView();
		}//ListView()
	}//class
}//namespace