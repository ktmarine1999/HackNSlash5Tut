using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISStackable
	{
		/// <summary>
		/// Gets the max stack.
		/// </summary>
		/// <value>The max items allowed in a stack.</value>
		int maxStack{ get; }

		/// <summary>
		/// Stack the specified amount.
		/// </summary>
		/// <param name="amount">The number of items to stack.</param>
		int stack(int amount);
	}
}