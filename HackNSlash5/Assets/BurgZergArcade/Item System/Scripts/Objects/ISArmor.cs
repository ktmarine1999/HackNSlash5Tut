#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [System.Serializable]
    public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject
    {
        #region IISArmor
        /// <summary>
        /// The Current defense rating of this armor
        /// </summary>
        [SerializeField]
        int _curArmor;

        /// <summary>
        /// The max defense rating of this armor
        /// </summary>
        [SerializeField]
        int _maxArmor;
        #endregion

        #region IISDestructable
        /// <summary>
        /// The durability of this armor.
        /// </summary>
        [SerializeField]
        int _durability;

        /// <summary>
        /// The max durability of this armor.
        /// </summary>
        [SerializeField]
        int _maxDurability;
        #endregion

        #region IISGameObject
        /// <summary>
        /// The prefab to display this item in the game world.
        /// </summary>
        [SerializeField]
        GameObject _prefab;
        #endregion

        public EquipmentSlot equipmentSlot;

        public ISArmor()
            : base()
        {
            // DatabaseManagment/DatabaseObject
            name = "New Armor";

            // ISArmor
            _curArmor = 0;
            _maxArmor = 0;
            equipmentSlot = EquipmentSlot.Armor_Head;

            // IISDestructable
            // all  new weapons are created as indestructable
            _maxDurability = -100;
            _durability = 1;
        }

        public override void Clone<T>(T dbObject)
        {
            base.Clone<T>(dbObject);

            ISArmor armor = dbObject as ISArmor;
            _curArmor = armor._curArmor;
            _maxArmor = armor._maxArmor;
            _durability = armor._durability;
            _maxDurability = armor._maxDurability;
            equipmentSlot = armor.equipmentSlot;
            _prefab = armor._prefab;
        }

        #region IISArmor Members
        public Vector2 armor
        {
            get
            {
                return new Vector2(_curArmor, _maxArmor);
            }
            set
            {
                //max is always greater than 0
                //cur is never less then 0
                //cur is never greater than max
                _maxArmor = Mathf.Max(0, (int)value.y);

                _curArmor = Mathf.Clamp((int)value.x, 1, _maxArmor);
            }
        }
        #endregion

        #region IISDestructable implementation
        /// <summary>
        /// Gets the durability.
        /// </summary>
        /// <value>The durability of this weapon.</value>
        public int durability
        {
            get { return _durability; }
        }

        /// <summary>
        /// Gets the max durability.
        /// </summary>
        /// <value>The max durability of this weapon. If set to -1 this weapon will not break.</value>
        public int maxDurability
        {
            get { return _maxDurability; }
        }

        /// <summary>
        /// This weapon Takes damage.
        /// </summary>
        /// <param name="amount">The amount of damage to do to the weapon.</param>
        public void TakeDamage(int amount)
        {
            // if this item is indestrucable then return no need to do anythins
            if (_maxDurability == -100)
                return;

            // reduce durability by the amount
            _durability -= amount;

            // if the durability is less then 0 or = 0 then break it
            if (_durability <= 0)
                Break();

        }

        /// <summary>
        /// Repair this weapon.
        /// </summary>
        public void Repair()
        {
            // if the max durability is greater then 0
            if (_maxDurability > 0)
            {
                // set the durability to the max durability
                _durability = _maxDurability;
            }
        }

        /// <summary>
        /// Break this weapon.
        /// </summary>
        public void Break()
        {
            // if this item is indestrucable then return no need to do anything
            if (_maxDurability == -100)
                return;

            // set _durability to zero
            _durability = 0;

            // if max durability is greater then 0 then reduce the max durability this prevents the item from becoming industructable
            if (_maxDurability > 0)
                _maxDurability--;
        }
        #endregion

        #region IISGameObject implementation
        /// <summary>
        /// Gets the prefab.
        /// </summary>
        /// <value>The prefab to display this item in the game world.</value>
        public GameObject prefab
        {
            get 
            {
                if (!_prefab)
                    _prefab = new GameObject();
                return _prefab;
            }
        }
        #endregion

#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();

            EditorGUILayout.LabelField("***ISArmor Members***");
            // Display the armor rating
            _curArmor = EditorGUILayout.IntField("Current Armor", _curArmor);
            _maxArmor = EditorGUILayout.IntField("Max Armor", _maxArmor);
            // Display the Durability
            _durability = EditorGUILayout.IntField("Current Durability", _durability);
            //Display the Max Durability
            _maxDurability = EditorGUILayout.IntField("Max Durability", _maxDurability);
            // Display the equipmentSlot pick from the Equipment slot database
            DisplayEquipmentSlot();
            // Display the prefab
            DisplayPrefab();
        }//OnGUI

        void DisplayEquipmentSlot()
        {
            equipmentSlot = (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
        }//DisplayEquipmentSlot

        void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }//Display Prefab
#endif
    }//class
}//namespace