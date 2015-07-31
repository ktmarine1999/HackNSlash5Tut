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
	}
}