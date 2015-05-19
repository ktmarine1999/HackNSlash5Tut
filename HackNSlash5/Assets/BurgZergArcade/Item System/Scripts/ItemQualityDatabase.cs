using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BurgZergArcade.ItemSystem
{
	public class ItemQualityDatabase : ScriptableObject
	{
		/// <summary>
		/// The database.
		/// </summary>
		[SerializeField]
		List<ItemQuality>
			database = new List<ItemQuality>();

		/// <summary>
		/// Gets the number of elements in the database.
		/// </summary>
		public int Count
		{
			get { return database.Count; }
		}

		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public void Add(ItemQuality item)
		{
			// Add the item to the database
			database.Add(item);
			// write the database to disk
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Insert the specified item at the index.
		/// </summary>
		/// <param name="index">Where to insert the item.</param>
		/// <param name="item">The item to insert.</param>
		public void Insert(int index, ItemQuality item)
		{
			database.Insert(index, item);
			// write the database to disk
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Remove the specified item.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public void Remove(ItemQuality item)
		{
			// remove the item from the database
			database.Remove(item);
			// write the database to disk
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Removes at index.
		/// </summary>
		/// <param name="index">The index to remove at.</param>
		public void Remove(int index)
		{
			// remove the item from the database
			database.RemoveAt(index);
			// write the database to disk
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Replace an item at a specified index.
		/// </summary>
		/// <param name="index">The index to replace.</param>
		/// <param name="item">The item to put at the index.</param>
		public void Replace(int index, ItemQuality item)
		{
			database[index] = item;
			// write the database to disk
			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Get an element at the specified index.
		/// </summary>
		/// <param name="index">The index to get an element at.</param>
		public ItemQuality Get(int index)
		{
			return database.ElementAt(index);
		}
	}
}