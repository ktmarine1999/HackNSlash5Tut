using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IEquipmentSlot
	{
		string Name { get; set; }

		Sprite Icon { get; set; }
	}
}