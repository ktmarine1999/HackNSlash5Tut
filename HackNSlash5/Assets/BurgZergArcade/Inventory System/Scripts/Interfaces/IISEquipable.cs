using UnityEngine;
using System.Collections;

namespace BurgZergArcade.InventorySystem
{
	public interface IISEquipable
	{
		/// <summary>
		/// Gets the eqipment slot.
		/// </summary>
		/// <value>The eqipment slot to equip this item in.</value>
		BurgZergArcade.ItemSystem.ISEquipmentSlot eqipmentSlot { get; }

		/// <summary>
		/// Equip this item.
		/// </summary>
		/// <returns>true if this item equiped scusessfully.</returns>
		bool Equip();
	}
}