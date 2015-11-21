#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace DatabaseManagment
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

        public virtual void Clone<T>(T dbObject) where T : DatabaseObject
        {
            _name = dbObject._name;
        }

#if UNITY_EDITOR
        public virtual void OnGUI()
        {
            EditorGUILayout.LabelField("***DatabaseObject Members***");
            // Display a field to edit the name
            _name = EditorGUILayout.TextField("Name", _name);
            GUILayout.Space(50);
        }
#endif
    }//class
}//namespace