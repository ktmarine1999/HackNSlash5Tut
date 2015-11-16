#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BurgZergArcade
{
	public class ScriptableObjectDatabase<T> : ScriptableObject where T: DatabaseObject
	{
		/// <summary>
		/// The database.
		/// </summary>
		[SerializeField]
		protected List<T>
			items = new List<T>();
		
#if UNITY_EDITOR
		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public void Add(T item)
		{
			// Add the item to the database
			items.Add(item);
			// Write the database to disk
			EditorUtility.SetDirty(this);
		}
		
		/// <summary>
		/// Insert the specified item at the index.
		/// </summary>
		/// <param name="index">Where to insert the item.</param>
		/// <param name="item">The item to insert.</param>
		public void Insert(int index, T item)
		{
			items.Insert(index, item);
			// Write the database to disk
			EditorUtility.SetDirty(this);
		}
		
		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public void Remove(T item)
		{
			// remove the item from the database
			items.Remove(item);
			// Write the database to disk
			EditorUtility.SetDirty(this);
		}
		
		/// <summary>
		/// Removes at index.
		/// </summary>
		/// <param name="index">The index to remove at.</param>
		public void Remove(int index)
		{
			// remove the item from the database
			items.RemoveAt(index);
			// Write the database to disk
			EditorUtility.SetDirty(this);
		}
		
		/// <summary>
		/// Replace an item at a specified index.
		/// </summary>
		/// <param name="index">The index to replace.</param>
		/// <param name="item">The item to put at the index.</param>
		public void Replace(int index, T item)
		{
			items[index] = item;
			// Write the database to disk
			EditorUtility.SetDirty(this);
		}
#endif
        /// <summary>
        /// Gets the number of elements in the database.
        /// </summary>
        public int Count
        {
            get { return items.Count; }
        }

		/// <summary>
		/// Get an element at the specified index.
		/// </summary>
		/// <param name="index">The index to get an element at.</param>
		public T Get(int index)
		{
			return items.ElementAt(index);
		}
	}
}