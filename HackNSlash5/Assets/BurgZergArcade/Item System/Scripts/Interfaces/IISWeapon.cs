﻿using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISWeapon
	{
		/// <summary>
		/// Gets or sets the minimum damage.
		/// </summary>
		/// <value>The minimum damage this weapon can do.</value>
		int minDamage{ get; set; }
	}//class
}//namespace