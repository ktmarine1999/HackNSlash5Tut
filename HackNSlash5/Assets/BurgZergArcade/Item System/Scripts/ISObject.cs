using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	[System.Serializable]
	public class ISObject : IISObject
	{
		/// <summary>
		/// The name of the Item.
		/// </summary>
		[SerializeField]
		string
			_name;

		/// <summary>
		/// The gold value of the Item.
		/// </summary>
		[SerializeField]
		int
			_value;

		/// <summary>
		/// The icon to use to display the Item.
		/// </summary>
		[SerializeField]
		Sprite
			_icon;

		/// <summary>
		/// How much of a burden is this Item on the player.
		/// </summary>
		[SerializeField]
		int
			_burden;

		/// <summary>
		/// The quality of the Item
		/// </summary>
		[SerializeField]
		ISQuality
			_quality;

	#region IISObject implementation
		/// <summary>
		/// Gets or sets the name of the Item.
		/// </summary>
		/// <value>The name of the Item.</value>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the Item value.
		/// </summary>
		/// <value>The gold value of the Item.</value>
		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}

		/// <summary>
		/// Gets or sets the Item icon.
		/// </summary>
		/// <value>The icon to use to display the Item.</value>
		public Sprite Icon
		{
			get { return _icon; }
			set { _icon = value; }
		}

		/// <summary>
		/// Gets or sets the Items burden.
		/// </summary>
		/// <value>How much of a burden is this Item on the player.</value>
		public int Burden
		{
			get { return _burden; }
			set { _burden = value; }
		}

		/// <summary>
		/// Gets or sets the Item quality.
		/// </summary>
		/// <value>The quality of the Item</value>
		public ISQuality Quality
		{
			get { return _quality; }
			set { _quality = value; }
		}
	#endregion

		public ISObject()
		{
			_name = "New Item";
			_value = 0;
			_icon = new Sprite();
			_burden = 1;
			_quality = new ISQuality();
		}//ISObject
	}//class
}//namespace