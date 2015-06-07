using UnityEngine;
using System.Collections;
using UnityEditor;

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
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the Item value.
		/// </summary>
		/// <value>The gold value of the Item.</value>
		public int itemValue
		{
			get { return _value; }
			set { _value = value; }
		}

		/// <summary>
		/// Gets or sets the Item icon.
		/// </summary>
		/// <value>The icon to use to display the Item.</value>
		public Sprite icon
		{
			get { return _icon; }
			set { _icon = value; }
		}

		/// <summary>
		/// Gets or sets the Items burden.
		/// </summary>
		/// <value>How much of a burden is this Item on the player.</value>
		public int burden
		{
			get { return _burden; }
			set { _burden = value; }
		}

		/// <summary>
		/// Gets or sets the Item quality.
		/// </summary>
		/// <value>The quality of the Item</value>
		public ISQuality quality
		{
			get { return _quality; }
			set { _quality = value; }
		}
	#endregion

//		public ISObject()
//		{
//			_name = "New Item";
//			_value = 0;
//			_icon = new Sprite();
//			_burden = 1;
//			_quality = new ISQuality();
//		}//ISObject

		ISQualityDatabase qdb;
		int _selectedQualityIndex = 0;
		string[] options;

		public ISObject()
		{
			// Initialize the quality database to use
			//qdb = BurgZergArcade.Editor.DatabaseEditor.InitDatabase<ISQualityDatabase>(BurgZergArcade.Editor.DatabaseManager.settings.itemQualityDatabase);
			qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>("BZADatabase", "ItemQualityDB");
			// Initialize the options string to be as big as the quality db
			options = new string[qdb.Count];

			//Loop through qdb and add the names to the options 
			for(int cnt = 0; cnt < qdb.Count; cnt++)
			{
				options[cnt] = qdb.Get(cnt).Name;
			}
		}

		public virtual void OnGUI()
		{
			// Create a vertical group Expanding the width
			EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
			
			// Display a field to edit the name
			_name = EditorGUILayout.TextField("Name", _name);
			
			//Display a filed to edit the value
			_value = EditorGUILayout.IntField("Value", _value);

			// Display the Burden
			_burden = EditorGUILayout.IntField("Burden", _burden);

			//Display the icon
			DisplayIcon();
			
			// Dispay the quality from the quality database
			DisplayQuality();

			// End the vertical group 
			EditorGUILayout.EndVertical();
		}//OnGUI

		public void DisplayIcon()
		{
			EditorGUILayout.LabelField("Icon");
		}//DisplayIcon

		public void DisplayQuality()
		{
			//EditorGUILayout.LabelField("Quality");

			_selectedQualityIndex = EditorGUILayout.Popup("Quality", _selectedQualityIndex, options);

		}//DisplayQuality
	}//class
}//namespace