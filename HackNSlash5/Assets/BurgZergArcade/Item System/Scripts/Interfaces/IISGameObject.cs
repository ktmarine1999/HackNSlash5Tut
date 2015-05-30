using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISGameObject
	{
		/// <summary>
		/// Gets the prefab.
		/// </summary>
		/// <value>The prefab to display this item in the game world.</value>
		GameObject prefab{ get; }
	}
}