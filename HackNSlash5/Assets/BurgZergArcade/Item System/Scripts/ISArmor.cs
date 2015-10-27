#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [System.Serializable]
    public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject
    {
        /// <summary>
        /// The durability of this weapon.
        /// </summary>
        [SerializeField]
        int
            _durability;

        /// <summary>
        /// The max durability of this weapon.
        /// </summary>
        [SerializeField]
        int
            _maxDurability;

        /// <summary>
        /// The prefab to display this item in the game world.
        /// </summary>
        [SerializeField]
        GameObject
            _prefab;

        public EquipmentSlot equipmentSlot;

        public ISArmor()
            : base()
        {
            name = "New Armor";
            equipmentSlot = EquipmentSlot.Armor_Head;

            // all  new weapons are created as indestructable
            _maxDurability = -100;
        }

        public ISArmor(int minDamage, int durability, int maxDurability, EquipmentSlot slot, GameObject gamePrefab)
        {
            _durability = durability;
            _maxDurability = maxDurability;
            equipmentSlot = slot;
            _prefab = gamePrefab;
        }

        public ISArmor(ISArmor armor)
        {
            Clone(armor);
        }

        public void Clone(ISArmor armor)
        {
            base.Clone(armor);
            _durability = armor._durability;
            _maxDurability = armor._maxDurability;
            equipmentSlot = armor.equipmentSlot;
            _prefab = armor._prefab;
        }

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
            // if this item is indestrucable then return no need to do anythins
            if (_maxDurability == -100)
                return;

            // set _durability to zero
            _durability = 0;

            // if max durability is greater then 0 then reduce the max durability this prevents the item from becoming industructable
            if (_maxDurability > 0)
                _maxDurability--;
        }
        #endregion

        #region IISEquipable implementation

        //		public ISEquipmentSlot eqipmentSlot
        //		{
        //			get
        //			{
        //				return _eqipmentSlot;
        //			}
        //		}
        //
        //		public bool Equip()
        //		{
        //			throw new System.NotImplementedException();
        //		}

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

            //Display the Durability
            //EditorGUILayout.LabelField("Durability");
            _durability = EditorGUILayout.IntField("Durability", _durability);

            //Display the Max Durability
            _maxDurability = EditorGUILayout.IntField("Max Durability", _maxDurability);

            // Display the equipmentSlot pick from the Equipment slot database
            DisplayEquipmentSlot();

            // Display the prefab
            DisplayPrefab();

            // End the vertical group 
            EditorGUILayout.EndVertical();
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