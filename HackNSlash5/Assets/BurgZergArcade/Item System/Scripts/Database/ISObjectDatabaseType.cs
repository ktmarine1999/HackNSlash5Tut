using System;
using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
    {
        [SerializeField]
        D database;

        [SerializeField]
        string dbName;

        [SerializeField]
        string dbPath = @"Database";

        public ISObjectDatabaseType(string n)
        {
            dbName = n;
        }

        public void OnEnabled()
        {
            if (database == null)
                LoadDatabase();
        }

        private void LoadDatabase()
        {
            throw new NotImplementedException();
        }

        public void OnGui()
        {

        }
    }
}
