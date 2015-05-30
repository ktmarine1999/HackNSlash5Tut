using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ObjectEditor
	{
		void TopTabBar()
		{
			EditorGUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			GUILayout.Button("Weapons");
			GUILayout.Button("Armor");
			GUILayout.Button("Consumables");
			GUILayout.Button("About");
			EditorGUILayout.EndHorizontal();
		}
	}//class
}//namespace