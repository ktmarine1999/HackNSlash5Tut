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

        /// <summary>
        /// List all of the Items in the passed in database.
        /// </summary>
        /// <typeparam name="T">The type of item that this database contains</typeparam>
        /// <param name="database">The database that you want to list</param>
        /// <param name="dbo">ref to an Item to </param>
        /// <param name="listScrollPosition">the scroll position for displaying the list</param>
        /// <param name="selectedIndex">Refrance to the items selected index</param>
        /// <param name="showNewDetails">Refrance to the show new details toggle</param>
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
                    selectedIndex = cnt;

                    //Debug.Log(database.GetType().ToString());

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

                    showNewDetails = true;
                    displayState = DisplayState.DETAILS;
                }//Item Button
            }//database loop

            // end the Scroll view
            EditorGUILayout.EndScrollView();
        }//listview
    }//class
}//namespace