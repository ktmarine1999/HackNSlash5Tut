using UnityEditor;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectCatagory<T>
    {
        public void ItemDetails()
        {
            // Create a vertical group Expanding the width and height
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            // Create a horizontal group expanding the width and height 
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (_showDetails)
                DisplayNewItem();

            // End Vertical group 
            EditorGUILayout.EndVertical();

            GUILayout.Space(50);

            // Create a horizontal group expanding the width
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            DisplayItemButtons();
            // End horizontal group 
            EditorGUILayout.EndHorizontal();

            // End the vertical group 
            EditorGUILayout.EndVertical();
        }//ItemObjectDetails()

        void DisplayNewItem()
        {
            if (_tempObject != null)
            {
                //EditorGUILayout.LabelField("New Weapon");
                _tempObject.OnGUI();
            }
        }//DisplayNewItem

        void DisplayItemButtons()
        {
            // If not showing new Item details then display the create Item button
            if (!_showDetails)
            {
                CreateButton();
            }//if !showNewWeaponDetails
            // Else show the save, dlete, and Cancel buttons
            else
            {
                SaveButton();
                DeleteButton();
                CancleButton();
            }//else
        }//DisplayButtons

        void CreateButton()
        {
            // Create a button to Create a new Item
            if (GUILayout.Button("Create " + _itemtype))
            {
                if (_database is ISWeaponDatabase)
                {
                    _tempObject = new ISWeapon() as T;
                }
                else if (_database is ISArmorDatabase)
                {
                    _tempObject = new ISArmor() as T;
                }
                else if (_database is ISConsumableDatabase)
                {
                    _tempObject = new ISConsumable() as T;
                }

                // Set the selected index to -1 indicating this item needs added to the _database when saved
                _selectedIndex = -1;

                // Set the toggel to true
                _showDetails = true;
            }//if Create Button
        }//CreateButton

        void SaveButton()
        {
            if (GUILayout.Button("Save"))
            {
                if (_selectedIndex == -1)
                {
                    _database.Add(_tempObject);
                }
                else
                {
                    _database.Replace(_selectedIndex, _tempObject);
                }

                // Set the toggel to false
                _showDetails = false;

                // Set tempObject to null to make sure the data gets cleared out
                _tempObject = null;

                // set the focus to be null. Makes it so their is no control focused next time you enter
                GUI.FocusControl(null);
            }//Save Button
        }//SaveButton

        void DeleteButton()
        {
            //If _showDetails and we are editing an item we need a delete button
            if (_showDetails && _selectedIndex > -1)
            {
                if (GUILayout.Button("Delete"))
                {
                    // Display a Are you sure Dialog and delete the quality to prevent accidental deletion
                    if (EditorUtility.DisplayDialog("Delete " + _itemtype,
                                                   "Are you sure you want to delete " + _database.Get(_selectedIndex).name + " from the database",
                                                   "Delete",
                                                   "Cancel"))
                    {
                        // since the user comfirmed it is ok delete the Item
                        //delete the current selected index put of the database
                        _database.Remove(_selectedIndex);

                        // Set the toggel to false
                        _showDetails = false;

                        // Set tempObject to null to make sure the data gets cleared out
                        _tempObject = null;

                        // set the focus to be null. Makes it so their is no control focused next time you enter
                        GUI.FocusControl(null);
                    }//Delete dialog
                }//if Delete Button
            }//_showDetails and we are editing an item
        }//Delete Button

        void CancleButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                // Set the toggel to false
                _showDetails = false;

                // Set tempObject to null to make sure the data gets cleared out
                _tempObject = null;

                // set the focus to be null. Makes it so their is no control focused next time you enter
                GUI.FocusControl(null);
            }//if Cancle Button
        }//Cancle Button
    }//class
}//namespace
