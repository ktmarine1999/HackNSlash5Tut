using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : DatabaseObject, new()
    {
        [SerializeField]
        D database;

        /// <summary>
        /// The temp item to edit the details so the database doesn't get changed until the item is saved.
        /// </summary>
        protected T tempItem;

        /// <summary>
        /// The selected index
        /// </summary>
        protected int selectedIndex = -1;

        /// <summary>
        /// The show new details.
        /// </summary>
        protected bool showDetails = false;

        /// <summary>
        /// String that contains the type of Item that's in this database
        /// Used in the button string of the Create Button
        /// </summary>
        protected string itemtype = "Item";

        public ISObjectDatabaseType(D db, string type)
        {
            database = db;
            itemtype = type;
        }

        public void OnGUI()
        {
            ListView();
            DetailsView();
        }
    }
}
