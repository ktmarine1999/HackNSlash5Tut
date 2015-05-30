using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor
	{
		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void ItemObjectDetails()
		{
			// Create a horizontal group box style expanding the width and height 
			EditorGUILayout.BeginHorizontal("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
			
			// Display the  selected Item Objects Details
			EditorGUILayout.LabelField("Details view");
			
			
			// end the Scroll view
			EditorGUILayout.EndHorizontal();
		}//ItemObjectDetails()
	}//class
}//namespace