using UnityEngine;
using UnityEditor;
using BurgZergArcade.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectEditor
    {
        void ItemDetails<T>(ScriptableObjectDatabase<T> database, string itemtype, ref T dbo, ref bool showNewItemDetails, ref int selectedIndex) where T : DatabaseObject
        {
            // Create a vertical group Expanding the width and height
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            // Create a horizontal group expanding the width and height 
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            switch (displayState)
            {
                case DisplayState.DETAILS:
                    if (showNewItemDetails)
                        DisplayNewItem<T>(ref dbo);
                    break;
                default:
                    break;
            }

            // End Vertical group 
            EditorGUILayout.EndVertical();

            GUILayout.Space(50);

            // Create a horizontal group expanding the width
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            DisplayItemButtons<T>(database, ref dbo, ref showNewItemDetails, itemtype, ref selectedIndex);
            // End horizontal group 
            EditorGUILayout.EndHorizontal();

            // End the vertical group 
            EditorGUILayout.EndVertical();
        }//ItemObjectDetails()

        void DisplayNewItem<T>(ref T dbo) where T : DatabaseObject
        {
            if (dbo != null)
            {
                //EditorGUILayout.LabelField("New Weapon");
                dbo.OnGUI();
            }
        }//DisplayNewItem

        void DisplayItemButtons<T>(ScriptableObjectDatabase<T> database, ref T dbo, ref bool showNewItemDetails, string itemtype, ref int selectedIndex) where T : DatabaseObject
        {
            // If not showing new Item details then display the create Item button
            if (!showNewItemDetails)
            {
                // Create a button to Create a new Item
                if (GUILayout.Button("Create " + itemtype))
                {
                    if (database is ISWeaponDatabase)
                    {
                        dbo = new ISWeapon() as T;
                    }
                    else if (database is ISArmorDatabase)
                    {
                        dbo = new ISArmor() as T;
                    }
                    else if (database is ISConsumableDatabase)
                    {
                        dbo = new ISConsumable() as T;
                    }

                    // Set the selected index to -1 indicating this item needs added to the database when saved
                    selectedIndex = -1;

                    // Set the toggel to true
                    showNewItemDetails = true;

                    // Set the DisplayState to Details
                    displayState = DisplayState.DETAILS;
                }//if Create Button
            }//if !showNewWeaponDetails
            // Else show the save and Cancel buttons
            else
            {
                if (GUILayout.Button("Save"))
                {
                    if (selectedIndex == -1)
                    {
                        database.Add(dbo);
                    }
                    else
                    {
                        database.Replace(selectedIndex, dbo);
                    }

                    // Set the toggel to false
                    showNewItemDetails = false;

                    // Set the DisplayState to NONE
                    displayState = DisplayState.NONE;

                    // Set dbo to null to make sure the data gets cleared out
                    dbo = null;

                    // set the focus to be null. Makes it so their is no control focused next time you enter
                    GUI.FocusControl(null);
                }//Save Button

                //If displayState == DisplayState.DETAILS and we are editing an item we need a delete button
                if (displayState == DisplayState.DETAILS && selectedIndex > -1)
                {
                    if (GUILayout.Button("Delete"))
                    {
                        // Display a Are you sure Dialog and delete the quality to prevent accidental deletion
                        if (EditorUtility.DisplayDialog("Delete " + itemtype,
                                                       "Are you sure you want to delete " + database.Get(selectedIndex).name + " from the database",
                                                       "Delete",
                                                       "Cancel"))
                        {
                            // since the user comfirmed it is ok delete the Item
                            //delete the current selected index put of the database
                            database.Remove(selectedIndex);

                            // Set the toggel to false
                            showNewItemDetails = false;

                            // Set the DisplayState to NONE
                            displayState = DisplayState.NONE;

                            // Set dbo to null to make sure the data gets cleared out
                            dbo = null;

                            // set the focus to be null. Makes it so their is no control focused next time you enter
                            GUI.FocusControl(null);
                        }//Delete dialog
                    }//Delete Button

                }//displayState.DETAILS

                if (GUILayout.Button("Cancel"))
                {
                    // Set the toggel to false
                    showNewItemDetails = false;

                    // Set the DisplayState to Details
                    displayState = DisplayState.NONE;

                    // Set dbo to null to make sure the data gets cleared out
                    dbo = null;

                    // set the focus to be null. Makes it so their is no control focused next time you enter
                    GUI.FocusControl(null);
                }//Cancle Button
            }//else
        }//DisplayButtons
    }//class
}//namespace