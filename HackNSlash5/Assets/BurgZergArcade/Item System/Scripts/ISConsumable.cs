#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [System.Serializable]
    public class ISConsumable : ISObject, IISConsumable, IISStackable, IISGameObject
    {
        int _maxStack;

        /// <summary>
        /// The prefab to display this item in the game world.
        /// </summary>
        [SerializeField]
        GameObject
            _prefab;

        public ISConsumable()
            : base()
        {
            name = "New Armor";
        }

        public ISConsumable(int maxStack, GameObject gamePrefab)
        {
            _maxStack = maxStack;
            _prefab = gamePrefab;
        }

        public ISConsumable(ISConsumable consumable)
        {
            Clone(consumable);
        }

        public void Clone(ISConsumable consumable)
        {
            base.Clone(consumable);
            _maxStack = consumable._maxStack;
            _prefab = consumable._prefab;
        }

        #region IISStackable Members
        public int maxStack
        {
            get { return _maxStack; }
        }

        public int stack(int amount)
        {
            //throw new System.NotImplementedException();
            return 0;
        }
        #endregion

        #region IISGameObject implementation

        /// <summary>
        /// Gets the prefab.
        /// </summary>
        /// <value>The prefab to display this item in the game world.</value>
        public GameObject prefab
        {
            get { return _prefab; }
        }

        #endregion

#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();

            // End the vertical group 
            EditorGUILayout.BeginVertical();

            _maxStack = EditorGUILayout.IntField("Max per stack:", _maxStack);

            // Display the prefab
            DisplayPrefab();

            // End the vertical group 
            EditorGUILayout.EndVertical();
        }//OnGUI

        void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }//Display Prefab
#endif
    }//class
}//namespace