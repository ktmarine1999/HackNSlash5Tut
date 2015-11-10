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

                    //Clone the Item so we are not working with the copy in the _database, in order to save these values have to click save
                    //_tempObject = new T(_database.Get(cnt)) as T; 
                    // error CS0304: Cannot create an instance of the variable type 'T' because it doesn't have the new() constraint
                    // workaround
                    if (_database is ISWeaponDatabase)
                    {
                        //_tempObject = new ISWeapon(_database.Get(cnt)) as T;
                        // error CS1502: The best overloaded method match for `BurgZergArcade.ItemSystem.ISWeapon.ISWeapon(BurgZergArcade.ItemSystem.ISWeapon)' has some invalid arguments
                        // error CS1503: Argument `#1' cannot convert `T' expression to type `BurgZergArcade.ItemSystem.ISWeapon'
                        // work around
                        _tempObject = new ISWeapon(DatabaseManager.weaponDatabase.Get(cnt)) as T;
                    }
                    else if (_database is ISArmorDatabase)
                    {
                        _tempObject = new ISArmor(DatabaseManager.armorDatabase.Get(cnt)) as T;
                    }
                    else if (_database is ISConsumableDatabase)
                    {
                        _tempObject = new ISConsumable(DatabaseManager.consumableDatabase.Get(cnt)) as T;
                    }

                    _showDetails = true;
                }//Item Button
            }//_database loop

            // end the Scroll view
            EditorGUILayout.EndScrollView();
        }//listview
    }//class
}//namespace