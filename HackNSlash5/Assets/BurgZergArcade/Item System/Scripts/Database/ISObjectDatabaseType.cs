using System;
using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
    {
        [SerializeField]
        D database;

        [SerializeField]
        string databaseName;

        [SerializeField]
        string databasePath;

        public ISObjectDatabaseType(string dbName)
        {
            databaseName = dbName;
        }

        public void OnEnabled()
        {
            if (database == null)
                LoadDatabase();
        }

        public void OnGUI()
        {

        }
    }
}
