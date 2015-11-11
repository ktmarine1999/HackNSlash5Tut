using BurgZergArcade.Editor;
using UnityEditor;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectCatagory<T>
    {
        /// <summary>
        /// The width of the listView
        /// </summary>
        protected int listViewWidth = 200;
        /// <summary>
        /// The width of the item button in the list
        /// </summary>
        protected int listViewButtonWidth = 190;
        /// <summary>
        /// The height of the item button in the list
        /// </summary>
        protected int listViewButtonHeight = 25;

        /// <summary>
        /// List all of the Items in the database.
        /// 
        /// if editing the details of an item in the database returns
        /// BeginScrollView("Box", ExpandHeight, Width(_listViewWidth))
        ///  loops through all of the items in the database to display them as a button if item is clicked
        ///   set the seleected index to the items index in the database
        ///   CloneItem()
        ///   set showDetails to true
        /// EndScrollView
        /// </summary>
        public void ListView()
        {
            if (showDetails)
                return;

            listScrollPos = EditorGUILayout.BeginScrollView(listScrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(listViewWidth));
            for (int cnt = 0; cnt < database.Count; cnt++)
            {
                if (GUILayout.Button(database.Get(cnt).name, "Box", GUILayout.Width(listViewButtonWidth), GUILayout.Height(listViewButtonHeight)))
                {
                    selectedIndex = cnt;
                    CloneItem();
                    showDetails = true;
                }//Item Button
            }//_database loop
            EditorGUILayout.EndScrollView();
        }//listview
    }//class
}//namespace