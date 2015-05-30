using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISEquipable
	{
		ISEequipmentSlot eqipmentSlot { get; }

		bool Equip();
	}
}