using UnityEngine;
using System.Collections;
using UnityEditor;
using DatabaseManagment;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : DatabaseObject, new()
    {
        /// <summary>
        /// Displays the items Details verticaly in a box with button laid out horizontaly underneath.
        /// 
        /// BeginVertical("Box", ExpandHeight, ExpandWidth)
        ///  BeginVertical(ExpandHeight, ExpandWidth)
        ///   if showDetails DisplayItemDetails
        ///  EndVertical
        ///  Space(50)
        ///  BeginHorizontal(ExpandWidth)
        ///   DisplayItemButtons
        ///  EndHorizontal
        /// EndVertical
        /// </summary>
        void DetailsView()
        {
            // Create a vertical group Expanding the width and height
            EditorGUILayout.BeginVertical("Box", GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            // Create a horizontal group expanding the width and height 
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (showDetails)
                DisplayItemDetails();

            // End Vertical group 
            EditorGUILayout.EndVertical();

            // Create some Empty Space
            GUILayout.Space(50);

            // Create a horizontal group expanding the width
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            // Display The Buttons
            DisplayItemButtons();
            // End horizontal group 
            EditorGUILayout.EndHorizontal();

            // End the vertical group 
            EditorGUILayout.EndVertical();
        }//DetailsView()

        /// <summary>
        /// if tempItem is not null
        ///  call the temp itemes OnGUI function
        /// </summary>
        void DisplayItemDetails()
        {
            if (tempItem != null)
                tempItem.OnGUI();
        }//DisplayNewItem

        /// <summary>
        /// Displays Buttons on the bottom of the page
        /// 
        /// If not showing item details:
        ///  Create Button
        /// 
        /// Else:
        ///  Save Button
        ///  Delete Button(If editing an item from the database selectedIndex > -1)
        ///  Cancel Button
        ///  
        /// </summary>
        void DisplayItemButtons()
        {
            // If not showing Item details then display the create Item button
            if (!showDetails)
            {
                ButtonCreate();
            }//if !showDetails
             // Else show the save, dlete, and Cancel buttons
            else
            {
                ButtonSave();
                //If editing an item we need a delete button
                if (selectedIndex > -1)
                    ButtonDelete();
                ButtonCancel();
            }//else
        }//DisplayButtons

        /// <summary>
        /// Displays a Button "Create " + itemType
        /// 
        /// When Clicked:
        ///  CreateNewItem();
        ///  makes sure the selectedIndex is set to -1
        ///  sets showDeyails to true
        ///  sets the focused GUI control to null (Makes it so their is no control focused next time you enter)
        /// </summary>
        void ButtonCreate()
        {
            if (GUILayout.Button("Create " + itemtype))
            {
                tempItem = new T();
                selectedIndex = -1;
                showDetails = true;
                GUI.FocusControl(null);
            }//if Create Button
        }//Create Button

        /// <summary>
        /// Displays a Button "Save"
        /// 
        /// When Clicked:
        ///  if new item Adds it to the database (selectedIndex == -1)
        ///  else replaces the item at the selectedIndex with the tempItem
        ///  sets showDetails to false (no longer want to show the details of an item being edited)
        ///  sets tempItem to null (no longer need the information stored here)
        ///  sets the focused GUI control to null (Makes it so their is no control focused next time you enter)
        /// </summary>
        void ButtonSave()
        {
            if (GUILayout.Button("Save"))
            {
                if (selectedIndex == -1)
                {
                    Add(tempItem);
                }
                else
                {
                    Replace(selectedIndex, tempItem);
                }

                showDetails = false;
                tempItem = null;
                GUI.FocusControl(null);
            }//Save Button
        }//Save Button

        /// <summary>
        /// Displays a Button "Delete"
        /// 
        /// When Clicked:
        ///  Displays a Delete item dialog with delete and cancel buttons, when delete is clicked
        ///   deletes the current selected item out of the database
        ///   sets showDetails to false (no longer want to show the details of an item being edited)
        ///   sets tempItem to null (no longer need the information stored here)
        ///   sets the focused GUI control to null (Makes it so their is no control focused next time you enter)
        /// </summary>
        void ButtonDelete()
        {
            if (GUILayout.Button("Delete"))
            {
                // Display a Are you sure Dialog and delete the quality to prevent accidental deletion
                if (EditorUtility.DisplayDialog("Delete " + tempItem.name,
                                               "Are you sure you want to delete " + tempItem.name + " from the database",
                                               "Delete",
                                               "Cancel"))
                {
                    Remove(selectedIndex);
                    showDetails = false;
                    tempItem = null;
                    GUI.FocusControl(null);
                }//Delete dialog
            }//if Delete Button
        }//Delete Button

        /// <summary>
        /// Displays a Button "Cancel"
        /// 
        /// When Clicked:
        ///  sets showDetails to false (no longer want to show the details of an item being edited)
        ///  sets tempItem to null (no longer need the information stored here)
        ///  sets the focused GUI control to null (Makes it so their is no control focused next time you enter)
        /// </summary>
        void ButtonCancel()
        {
            if (GUILayout.Button("Cancel"))
            {
                showDetails = false;
                tempItem = null;
                GUI.FocusControl(null);
            }//if Cancel Button
        }//Cancle Button
    }
}
