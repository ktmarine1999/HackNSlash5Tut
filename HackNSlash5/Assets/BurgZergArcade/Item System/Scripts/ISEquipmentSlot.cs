using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ISEquipmentSlot : DatabaseObject, IISEquipmentSlot
	{	
		/// <summary>
		/// The icon representation of the equipment.
		/// </summary>
		[SerializeField]
		Sprite
			_icon;

		public ISEquipmentSlot()
		{
			_name = "Name Me";
			_icon = new Sprite();
		}

		#region IEquipmentSlot implementation		
		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon representation of the equipment slot.</value>
		public Sprite icon
		{
			get { return _icon; }
			set { _icon = value; }
		}
		#endregion
	}//class
}//namespace