using UnityEngine;
using System.Collections;

namespace BurgZergArcade.InventorySystem
{
	public interface IISEquipmentSlot
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name of the equipment slot.</value>
		string name { get; set; }

		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon to use to display the equipment slot.</value>
		Sprite icon { get; set; }
	}
}