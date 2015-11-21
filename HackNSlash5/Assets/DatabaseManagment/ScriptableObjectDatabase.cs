using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseManagment
{
    public class ScriptableObjectDatabase<T> : ScriptableObject where T : DatabaseObject
    {
        /// <summary>
        /// The database.
        /// </summary>
        [SerializeField]
        protected List<T> items = new List<T>();

        public List<T> Items
        {
            get { return items; }
        }

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