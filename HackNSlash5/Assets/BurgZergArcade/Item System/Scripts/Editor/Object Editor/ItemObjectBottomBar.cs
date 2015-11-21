using UnityEngine;
using UnityEditor;
using DatabaseManagment.Editor;

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

            switch (tabState)
            {
                case TabState.WEAPON:
                    EditorGUILayout.LabelField("Weapons: " + (DatabaseManager.weaponDatabase.Count).ToString());
                    break;
                case TabState.ARMOR:
                    EditorGUILayout.LabelField("Armors: " + (DatabaseManager.armorDatabase.Count).ToString());
                    break;
                case TabState.CONSUMABLE:
                    EditorGUILayout.LabelField("Consumables: " + (DatabaseManager.consumableDatabase.Count).ToString());
                    break;
                case TabState.QUALITY:
                    EditorGUILayout.LabelField("Qualities: " + (DatabaseManager.qualityDatabase.Count).ToString());
                    break;
                default:
                    EditorGUILayout.LabelField("Tab State: " + tabState);
                    break;
            }

            // end the Scroll view
            EditorGUILayout.EndHorizontal();
		}//ItemObjectDetails()
	}//class
}//namespace