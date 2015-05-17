using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ItemQuality : IQuality
	{
		/// <summary>
		/// The name of the qulity.
		/// </summary>
		[SerializeField]
		string
			_name;

		/// <summary>
		/// The icon representation of the qulity.
		/// </summary>
		[SerializeField]
		Sprite
			_icon;

	#region IISQuality implementation
		/// <summary>
		/// Gets or sets the qulity name.
		/// </summary>
		/// <value>The name of the qulity.</value>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon representation of the qulity.</value>
		public Sprite Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}
	#endregion

		public ItemQuality()
		{
			_name = "Common";
			_icon = new Sprite();
		}
	}
}