using UnityEngine;
using System.Collections;
using UnityEditor;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISEquipable, IISGameObject
	{
		/// <summary>
		/// Theminimum damage this weapon can do.
		/// </summary>
		[SerializeField]
		int
			_minDamage;

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
		/// The eqipment slot to equip this item in.
		/// </summary>
		[SerializeField]
		ISEquipmentSlot
			_eqipmentSlot;

		/// <summary>
		/// The prefab to display this item in the game world.
		/// </summary>
		[SerializeField]
		GameObject
			_prefab;

		public ISWeapon()
		{
			_eqipmentSlot = new BurgZergArcade.ItemSystem.ISEquipmentSlot();
		}

		public ISWeapon(int durability, int maxDurability, ISEquipmentSlot slot, GameObject gamePrefab)
		{
			_durability = durability;
			_maxDurability = maxDurability;
			_eqipmentSlot = slot;
			_prefab = gamePrefab;
		}

		#region IISWeapon implementation
		/// <summary>
		/// Gets or sets the minimum damage.
		/// </summary>
		/// <value>The minimum damage this weapon can do.</value>
		public int minDamage
		{
			get{ return _minDamage;}
			set{ _minDamage = value;}
		}

		/// <summary>
		/// Use this weapon to attack.
		/// </summary>
		/// <returns>Amount of damage to do when attacking</returns>
		public int Attack()
		{
			throw new System.NotImplementedException();
		}
		#endregion

		#region IISDestructable implementation
		/// <summary>
		/// Gets the durability.
		/// </summary>
		/// <value>The durability of this weapon.</value>
		public int durability
		{
			get{ return _durability;}
		}

		/// <summary>
		/// Gets the max durability.
		/// </summary>
		/// <value>The max durability of this weapon. If set to -1 this weapon will not break.</value>
		public int maxDurability
		{
			get{ return _maxDurability;}
		}

		/// <summary>
		/// This weapon Takes damage.
		/// </summary>
		/// <param name="amount">The amount of damage to do to the weapon.</param>
		public void TakeDamage(int amount)
		{
			// if this item is indestrucable then return no need to do anythins
			if(_maxDurability == -1)
				return;

			// reduce durability by the amount
			_durability -= amount;

			// if the durability is less then 0 or = 0 then break it
			if(_durability <= 0)
				Break();

		}

		/// <summary>
		/// Repair this weapon.
		/// </summary>
		public void Repair()
		{
			// if the max durability is greater then 0
			if(_maxDurability > 0)
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
			if(_maxDurability == -1)
				return;

			// set _durability to zero
			_durability = 0;

			// if max durability is greater then 0 then reduce the max durability this prevents the item from becoming industructable
			if(_maxDurability > 0)
				_maxDurability--;
		}
		#endregion

		#region IISEquipable implementation
		/// <summary>
		/// Gets the eqipment slot.
		/// </summary>
		/// <value>The eqipment slot.</value>
		public ISEquipmentSlot eqipmentSlot
		{
			get{ return _eqipmentSlot;}
		}

		/// <summary>
		/// Equip this weapon.
		/// </summary>
		/// <returns>true if this wepon equiped scusessfully.</returns>
		public bool Equip()
		{
			throw new System.NotImplementedException();
		}
		#endregion

		#region IISGameObject implementation
		/// <summary>
		/// Gets the prefab.
		/// </summary>
		/// <value>The prefab to display this item in the game world.</value>
		public GameObject prefab
		{
			get{ return _prefab;}
		}

		#endregion

		public void OnGUI()
		{
			// Create a vertical group Expanding the width
			EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
			// Display a field to edit the name
			name = EditorGUILayout.TextField("Name", name);
			
			//Display a filed to edit the value
			itemValue = int.Parse(EditorGUILayout.TextField("Value", itemValue.ToString()));
			
			//Display the icon
			
			// Display the Burden
			burden = int.Parse(EditorGUILayout.TextField("Burden", burden.ToString()));
			
			// Dispay the quality from the quality database
			
			//Display the Min Damage
			_minDamage = int.Parse(EditorGUILayout.TextField("Min Damage", _minDamage.ToString()));
			
			//Display the Durability
			_durability = int.Parse(EditorGUILayout.TextField("Durability", _durability.ToString()));
			
			//Display the Max Durability
			_maxDurability = int.Parse(EditorGUILayout.TextField("Max Durability", _maxDurability.ToString()));
			
			// Display the equipmentSlot again pick from the Equipment slot database


			// Display the prefab


			// End the vertical group 
			EditorGUILayout.EndVertical();
		}
	}//class
}//namespace