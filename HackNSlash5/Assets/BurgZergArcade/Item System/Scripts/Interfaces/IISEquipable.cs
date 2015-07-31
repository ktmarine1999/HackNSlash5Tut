using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISEquipable
	{
		/// <summary>
		/// Gets the eqipment slot.
		/// </summary>
		/// <value>The eqipment slot to equip this item in.</value>
		ISEquipmentSlot eqipmentSlot { get; }
	}
}