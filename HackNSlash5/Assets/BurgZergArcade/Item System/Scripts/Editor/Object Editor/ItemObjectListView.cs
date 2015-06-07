using UnityEngine;
using UnityEditor;

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

		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void ListView()
		{
			// Contain the Item Object in a scroll view
			_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

			// Display the Item Objects in the database


			// end the Scroll view
			EditorGUILayout.EndScrollView();
		}//ListView()
	}//class
}//namespace