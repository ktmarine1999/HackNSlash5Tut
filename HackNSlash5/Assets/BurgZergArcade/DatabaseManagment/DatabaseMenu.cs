using UnityEditor;
using UnityEngine;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database editor.
	/// A helper class use to load editor windows and scriptable objects.
	/// </summary>
	public static partial class DatabaseEditor
	{
		#region Create Databases
		[MenuItem("Assets/BZA/Create/Item System/Quality Database")]
		public static void CreateISQualityDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ISQualityDatabase>();
		}

		[MenuItem("Assets/BZA/Create/Item System/Equipment Slot Database")]
		public static void CreateISEquipmentSlotDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ISEquipmentSlotDatabase>();
		}

		[MenuItem("Assets/BZA/Create/Item System/Object Database")]
		public static void CreateItemObjectDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ISObjectDatabase>();
		}

		[MenuItem("Assets/BZA/Create/Item System/Weapon Database")]
		public static void CreateWeaponDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ISWeaponDatabase>();
		}


		/// <summary>
		/// Create new asset from <see cref="ScriptableObject"/> type with unique name at
		/// selected folder in project window. Asset creation can be cancelled by pressing
		/// escape key when asset is initially being named.
		/// </summary>
		/// <typeparam name="T">Type of scriptable object.</typeparam>
		public static void CreateAsset<T>() where T : ScriptableObject
		{
			T asset = ScriptableObject.CreateInstance<T>();
			ProjectWindowUtil.CreateAsset(asset, "New " + typeof(T).Name + ".asset");
		}
		#endregion

		#region Set selected database to the active database
		/// <summary>
		/// Sets the selected database as the database to use.
		/// </summary>
		[MenuItem("Assets/BZA/Set Active/Item System/Quality Database")]
		static void SetISQualityDBActive()
		{
			DatabaseManager.settings.ISQualityDatabaseName = Selection.activeObject.name;
			// write the changes to disk
			EditorUtility.SetDirty(DatabaseManager.settings);
		}

		/// <summary>
		/// Sets the selected database as the database to use.
		/// </summary>
		[MenuItem("Assets/BZA/Set Active/Item System/Equipment Slot Database")]
		static void SetISEquipmentSlotDBActive()
		{
			DatabaseManager.settings.ISEquipmentSlotDatabaseName = Selection.activeObject.name;
			// write the changes to disk
			EditorUtility.SetDirty(DatabaseManager.settings);
		}

		/// <summary>
		/// Sets the selected database as the database to use.
		/// </summary>
		[MenuItem("Assets/BZA/Set Active/Item System/Object Database")]
		static void SetISObjectDBActive()
		{
			DatabaseManager.settings.ISObjectDatabaseName = Selection.activeObject.name;
			// write the changes to disk
			EditorUtility.SetDirty(DatabaseManager.settings);
		}

		/// <summary>
		/// Sets the selected database as the database to use.
		/// </summary>
		[MenuItem("Assets/BZA/Set Active/Item System/Weapon Database")]
		static void SetISWeaponDBActive()
		{
			DatabaseManager.settings.ISWeaponDatabaseName = Selection.activeObject.name;
			// write the changes to disk
			EditorUtility.SetDirty(DatabaseManager.settings);
		}
		#endregion
	}//class
}//namespace