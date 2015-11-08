using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectCatagory<T> where T : DatabaseObject
    {
        /// <summary>
        /// The temp object to edit that gets created to create a new object.
        /// </summary>
        T tempObject;

        ScriptableObjectDatabase<T> _database;

        /// <summary>
        /// The scroll position.
        /// Used in ListView when display the List;
        /// </summary>
        Vector2 _listScrollPos = Vector2.zero;

        /// <summary>
        /// The selected index
        /// </summary>
        int _selectedIndex = -1;

        /// <summary>
        /// The show new details.
        /// </summary>
        bool _showDetails = false;

        string _itemtype = "Item";

        public ItemObjectCatagory(ScriptableObjectDatabase<T> database, string itemType)
        {
            _database = database;
            _itemtype = itemType;
        }
    }
}
