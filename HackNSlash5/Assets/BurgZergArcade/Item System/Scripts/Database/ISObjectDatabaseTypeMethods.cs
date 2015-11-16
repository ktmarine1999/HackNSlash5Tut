using DatabaseManagment;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using DatabaseManagment.Editor;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
    {
        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Add(T item)
        {
            // Add the item to the database
            database.Items.Add(item);
            // Write the database to disk
            EditorUtility.SetDirty(database);
        }

        /// <summary>
        /// Insert the specified item at the index.
        /// </summary>
        /// <param name="index">Where to insert the item.</param>
        /// <param name="item">The item to insert.</param>
        public void Insert(int index, T item)
        {
            database.Items.Insert(index, item);
            // Write the database to disk
            EditorUtility.SetDirty(database);
        }

        /// <summary>
        /// Remove the specified item.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public void Remove(T item)
        {
            // remove the item from the database
            database.Items.Remove(item);
            // Write the database to disk
            EditorUtility.SetDirty(database);
        }

        /// <summary>
        /// Removes at index.
        /// </summary>
        /// <param name="index">The index to remove at.</param>
        public void Remove(int index)
        {
            // remove the item from the database
            database.Items.RemoveAt(index);
            // Write the database to disk
            EditorUtility.SetDirty(database);
        }

        /// <summary>
        /// Replace an item at a specified index.
        /// </summary>
        /// <param name="index">The index to replace.</param>
        /// <param name="item">The item to put at the index.</param>
        public void Replace(int index, T item)
        {
            database.Items[index] = item;
            // Write the database to disk
            EditorUtility.SetDirty(database);
        }

        private void LoadDatabase()
        {
            // set the full path of the scriptable object to load or create
            string dbFullPath = @"Assets/";

            // Check to make sure that the db Folder is not null or empty
            if (!string.IsNullOrEmpty(databasePath))
                dbFullPath += databasePath + "/" + databaseName + ".asset";
            else if (string.IsNullOrEmpty(DatabaseManager.DATABASE_FOLDER_NAME))
                dbFullPath += databaseName + ".asset";
            else
                dbFullPath += DatabaseManager.DATABASE_FOLDER_NAME + "/" + databaseName + ".asset";

            // Load the database
            database = AssetDatabase.LoadAssetAtPath<D>(dbFullPath);

            // If the database failed to load, create one
            if (database == null)
                CreateDatabase(dbFullPath);
        }

        void CreateDatabase(string dbFullPath)
        {
            // Check to see if the folder exist, if not create it

            // Log a message that no database was loaded
            Debug.Log("Failed to load " + dbFullPath);

            string dbPath;

            if (!string.IsNullOrEmpty(databasePath))
                dbPath = databasePath;
            else if (string.IsNullOrEmpty(DatabaseManager.DATABASE_FOLDER_NAME))
                dbPath = "";
            else
                dbPath = DatabaseManager.DATABASE_FOLDER_NAME;

            // First check if the database folder is there
            if (!string.IsNullOrEmpty(dbPath) && !AssetDatabase.IsValidFolder(@"Assets/" + dbPath))
            {
                // Log a message that the path needs created
                Debug.Log("Path " + @"Assets/" + dbPath + " is not valid");

                // If not then create the database folder
                AssetDatabase.CreateFolder("Assets", dbPath);
            }

            // Create a new instance of the database
            database = ScriptableObject.CreateInstance<D>();
            // Create a new database at the location given so we can load it the next time
            AssetDatabase.CreateAsset(database, dbFullPath);
            // Save the database
            AssetDatabase.SaveAssets();
            // Refresh the AssetDatabase
            AssetDatabase.Refresh();
            //Set the window to to focus on to be the project winodw
            EditorUtility.FocusProjectWindow();
            // select the new created db
            Selection.activeObject = database;
        }
    }
}
