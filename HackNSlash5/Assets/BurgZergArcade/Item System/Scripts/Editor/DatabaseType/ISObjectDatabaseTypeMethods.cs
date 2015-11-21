using DatabaseManagment;
using DatabaseManagment.Editor;
using UnityEditor;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : DatabaseObject, new()
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
    }
}
