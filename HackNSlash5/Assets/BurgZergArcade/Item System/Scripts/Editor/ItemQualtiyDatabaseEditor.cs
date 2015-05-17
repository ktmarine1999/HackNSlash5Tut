using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public class ItemQualtiyDatabaseEditor : EditorWindow
	{
		ItemQualityDatabase db;

		[MenuItem("BZA/Database/Quality Editor %#i")]
		public static void Init()
		{
			DatabaseEditor.InitEditorWindow<ItemQualtiyDatabaseEditor>(new Vector2(400, 300), "Quality Database");
		}

		void OnEnable()
		{
			db = DatabaseEditor.CreateDatabase<ItemQualityDatabase>(DatabasePrefs.itemQualityDatabase);
		}

		void OnGUI()
		{
			if(db.db.Count > 0)
			{
				for(int cnt = 0; cnt < db.db.Count; cnt++)
				{
					EditorGUILayout.TextField("Quality Name", db.db[cnt].Name, GUILayout.ExpandWidth(false));
				}
			}
		}
	}
}