using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ItemEequipmentSlot : IISEquipmentSlot
	{
		/// <summary>
		/// The name of the equipment slot.
		/// </summary>
		[SerializeField]
		string
			_name;
		
		/// <summary>
		/// The icon representation of the equipment.
		/// </summary>
		[SerializeField]
		Sprite
			_icon;

		#region IEquipmentSlot implementation
		/// <summary>
		/// Gets or sets the equipment slots name.
		/// </summary>
		/// <value>The name of the equipment slot.</value>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		
		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon representation of the equipment slot.</value>
		public Sprite Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}
		#endregion
	}
}