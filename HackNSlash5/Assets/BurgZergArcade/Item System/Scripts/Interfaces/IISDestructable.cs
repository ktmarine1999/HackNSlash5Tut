﻿using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISDestructable
	{
		/// <summary>
		/// Gets the durability.
		/// </summary>
		/// <value>The durability of this item.</value>
		int durability { get; }

		/// <summary>
		/// Gets the max durability.
		/// </summary>
		/// <value>The max durability of this item.  If set to -1 this item will not break.</value>
		int maxDurability { get; }
	}
}