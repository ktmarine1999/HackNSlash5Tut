using BurgZergArcade.Editor;
using UnityEditor;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectCatagory<T>
    {
        int _listViewWidth = 200;
        int _listViewButtonWidth = 190;
        int _listViewButtonHeight = 25;

        /// <summary>
        /// List all of the Items in the passed in _database.
        /// </summary>
        public void ListView()
        {
            // Only display the list if the display state == DisplayState.NONE
            if (_showDetails)
                return;

            // Contain the Item Object in a scroll view
            _listScrollPos = EditorGUILayout.BeginScrollView(_listScrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            // Display the Objects in the _database
            for (int cnt = 0; cnt < _database.Count; cnt++)
            {
                if (GUILayout.Button(_database.Get(cnt).name, "Box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight)))
                {
                    _selectedIndex = cnt;

                    //Debug.Log(_database.GetType().ToString());

                    //Clone the Item so we are not working with the copy in the _database, in order to save these values have to click save
                    if (_database is ISWeaponDatabase)
                    {
                        tempObject = new ISWeapon(DatabaseManager.weaponDatabase.Get(cnt)) as T;
                    }
                    else if (_database is ISArmorDatabase)
                    {
                        tempObject = new ISArmor(DatabaseManager.armorDatabase.Get(cnt)) as T;
                    }
                    else if (_database is ISConsumableDatabase)
                    {
                        tempObject = new ISConsumable(DatabaseManager.consumableDatabase.Get(cnt)) as T;
                    }

                    _showDetails = true;
                }//Item Button
            }//_database loop

            // end the Scroll view
            EditorGUILayout.EndScrollView();
        }//listview
    }//class
}//namespace