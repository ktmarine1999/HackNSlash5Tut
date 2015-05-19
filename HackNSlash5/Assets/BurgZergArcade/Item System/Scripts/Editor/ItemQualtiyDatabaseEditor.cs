using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public class ItemQualtiyDatabaseEditor : EditorWindow
	{
		ItemQualityDatabase qualityDatabase;
		ItemQuality selectedItem;
		Texture2D selectedTexture;

		const int SPRITE_BUTTON_SIZE = 46;

		[MenuItem("BZA/Database/Quality Editor %#i")]
		public static void Init()
		{
			DatabaseEditor.InitEditorWindow<ItemQualtiyDatabaseEditor>();
		}

		void OnEnable()
		{
			qualityDatabase = DatabaseEditor.CreateDatabase<ItemQualityDatabase>(DatabaseManager.settings.itemQualityDatabase);

			selectedItem = new ItemQuality();
		}

		void OnGUI()
		{
			AddQualityToDatabase();
			if(qualityDatabase.Count > 0)
			{
				for(int cnt = 0; cnt < qualityDatabase.Count; cnt++)
				{
					EditorGUILayout.TextField("Quality Name", qualityDatabase.Get(cnt).Name, GUILayout.ExpandWidth(false));
				}
			}
		}

		void AddQualityToDatabase()
		{
			selectedItem.Name = EditorGUILayout.TextField("Name:", selectedItem.Name);
			//sprite
			if(selectedItem.Icon)
				selectedTexture = selectedItem.Icon.texture;
			else
				selectedTexture = null;

			if(GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
			{
				int controlerID = EditorGUIUtility.GetControlID(FocusType.Passive);
				EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlerID);
			}

			string commandName = Event.current.commandName;
			if(commandName == "ObjectSelectorUpdated")
			{
				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
				Repaint();
			}

			if(GUILayout.Button("Save"))
			{
				if(selectedItem == null)
					return;

				qualityDatabase.Add(selectedItem);

				selectedItem = new ItemQuality();
			}
		}
	}
}