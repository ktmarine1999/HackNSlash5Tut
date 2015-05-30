using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISEquipmentSlot
	{
		string Name { get; set; }

		Sprite Icon { get; set; }
	}
}