using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISObject
	{
		/// <summary>
		/// Gets or sets the name of the Item.
		/// </summary>
		/// <value>The name of the Item.</value>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the Item value.
		/// </summary>
		/// <value>The gold value of the Item.</value>
		int Value { get; set; }

		/// <summary>
		/// Gets or sets the Item icon.
		/// </summary>
		/// <value>The icon to use to display the Item.</value>
		Sprite Icon { get; set; }

		/// <summary>
		/// Gets or sets the Items burden.
		/// </summary>
		/// <value>How much of a burden is this Item on the player.</value>
		int Burden { get; set; }

		/// <summary>
		/// Gets or sets the Item quality.
		/// </summary>
		/// <value>The quality of the Item</value>
		ItemQuality Quality { get; set; }

		//questItem flag
		//prefab
	}
}