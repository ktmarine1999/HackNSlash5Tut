using UnityEngine;
using System.Collections;

namespace BurgZergArcade.InventorySystem
{
	public interface IISWeapon
	{
		/// <summary>
		/// Gets or sets the minimum damage.
		/// </summary>
		/// <value>The minimum damage this weapon can do.</value>
		int minDamage{ get; set; }

		/// <summary>
		/// Use this weapon to attack.
		/// </summary>
		/// <returns>amount of damage to do when attacking</returns>
		int Attack();
	}//class
}//namespace