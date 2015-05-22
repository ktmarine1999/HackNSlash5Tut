using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IDestructable
	{
		//durability
		int Durability { get; }
		int MaxDurability { get; }
		void TakeDamage(int amount);
		void Repair();
		void Break();
	}
}