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
		[MenuItem("Assets/BZA/Create/Quality Database")]
		public static void CreateItemQualityDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ISQualityDatabase>();
		}

		[MenuItem("Assets/BZA/Create/Item Object Database")]
		public static void CreateItemObjectDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ISObjectDatabase>();
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
		[MenuItem("Assets/BZA/Set Active/Quality Database")]
		static void SetQualityDBActive()
		{
			DatabaseManager.settings.itemQualityDatabase = Selection.activeObject.name;
			// write the changes to disk
			EditorUtility.SetDirty(DatabaseManager.settings);
		}

		/// <summary>
		/// Sets the selected database as the database to use.
		/// </summary>
		[MenuItem("Assets/BZA/Set Active/Item Object Database")]
		static void SetItemObjectDBActive()
		{
			DatabaseManager.settings.itemObjectDatabase = Selection.activeObject.name;
			// write the changes to disk
			EditorUtility.SetDirty(DatabaseManager.settings);
		}
		#endregion
	}//class
}//namespace