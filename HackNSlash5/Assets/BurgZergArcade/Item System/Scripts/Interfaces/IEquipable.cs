using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISEquipable
	{
		ItemEequipmentSlot eqipmentSlot { get; }

		bool Equip();
	}
}