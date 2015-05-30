using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor
	{
		/// <summary>
		/// List all of the Items in the database
		/// </summary>
		private void BottomBar()
		{
			// Create a horizontal group box style expanding the width. 
			EditorGUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			
			// Display the  selected Status
			EditorGUILayout.LabelField("Bottom Bar");
			
			
			// end the Scroll view
			EditorGUILayout.EndHorizontal();
		}//ItemObjectDetails()
	}//class
}//namespace