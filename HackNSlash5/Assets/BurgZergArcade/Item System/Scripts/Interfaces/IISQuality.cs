using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISQuality
	{
		/// <summary>
		/// Gets or sets the qulity name.
		/// </summary>
		/// <value>The name of the qulity.</value>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon representation of the qulity.</value>
		Sprite Icon { get; set; }
	}
}