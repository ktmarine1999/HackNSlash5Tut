using UnityEngine;
using System.Collections;

using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectEditor
    {
        int _listViewWidth = 200;
        int _listViewButtonWidth = 190;
        int _listViewButtonHeight = 25;

        private void ListView<T>(ScriptableObjectDatabase<T> database, ref T dbo, ref Vector2 listScrollPosition, ref int selectedIndex, ref bool showNewDetails) where T : DatabaseObject
        {
            // Only display the list if the display state == DisplayState.NONE
            if (displayState != DisplayState.NONE)
                return;

            // Contain the Item Object in a scroll view
            listScrollPosition = EditorGUILayout.BeginScrollView(listScrollPosition, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            // Display the Objects in the database
            for (int cnt = 0; cnt < database.Count; cnt++)
            {
                if (GUILayout.Button(database.Get(cnt).name, "Box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight)))
                {
                    //Debug.Log(database.Get(cnt).name + " : " + cnt);
                    selectedIndex = cnt;

                    //Clone the Item so we are not working with the copy in the database, in order to save these values have to click save
                    if (database is ISWeaponDatabase)
                    {
                        dbo = new ISWeapon(DatabaseManager.weaponDatabase.Get(cnt)) as T;
                    }
                    else if(database is ISArmorDatabase)
                    {
                        dbo = new ISArmor(DatabaseManager.armorDatabase.Get(cnt)) as T;
                    }
                    else if (database is ISConsumableDatabase)
                    {
                        dbo = new ISConsumable(DatabaseManager.consumableDatabase.Get(cnt)) as T;
                    }

                    //Debug.Log(database.GetType().ToString());

                    showNewDetails = true;
                    displayState = DisplayState.DETAILS;
                }
            }

            // end the Scroll view
            EditorGUILayout.EndScrollView();
        }
    }//class
}//namespace