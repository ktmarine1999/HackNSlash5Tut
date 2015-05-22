using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IEquipable
	{
		ItemEequipmentSlot eqipmentSlot { get; }

		bool Equip();
	}
}