using UnityEngine;

namespace BurgZergArcade
{
    [System.Serializable]
    public class DatabaseObject
    {
        /// <summary>
        /// The name of the Object.
        /// </summary>
        [SerializeField]
        protected string _name;

        /// <summary>
        /// Gets or sets the name of the Object.
        /// </summary>
        /// <value>The name of the Object.</value>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DatabaseObject() { }

        public DatabaseObject(DatabaseObject dbObject)
		{
            Clone(dbObject);
		}

        public void Clone(DatabaseObject dbObject)
		{
            _name = dbObject._name;
		}

        public virtual void OnGUI() { }
    }//class
}//namespace