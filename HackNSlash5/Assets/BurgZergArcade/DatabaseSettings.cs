using UnityEngine;
using System.Collections;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database settings.
	/// All of the database folders and file names to use in editor scripts
	/// </summary>
	[System.Serializable]
	public class DatabaseSettings : ScriptableObject
	{
		/// <summary>
		/// The folder that the databases reside in.
		/// </summary>
		public string databaseFolder;

		/// <summary>
		/// The name of the item quality database
		/// </summary>
		public string itemQualityDatabase = "ItemQualityDB";

		/// <summary>
		/// The name of the item object database.
		/// </summary>
		public string itemObjectDatabase = "ItemObjectDB";

		/// <summary>
		/// The name of the weapon database.
		/// </summary>
		public string weaponDatabase = "weaponDB";
	}
}