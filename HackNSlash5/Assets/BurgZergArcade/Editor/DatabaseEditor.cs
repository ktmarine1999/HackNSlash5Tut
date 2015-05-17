using UnityEngine;
using UnityEditor;
using System.IO;

namespace BurgZergArcade.Editor
{
	public static class DatabaseEditor
	{
		public static void InitEditorWindow<T>(Vector2 minSize, string title) where T : EditorWindow
		{
			T window = EditorWindow.GetWindow<T>();
			window.minSize = minSize;
			window.title = title;
			window.Show();
		}

		public static T CreateDatabase<T>(string databaseName) where T : ScriptableObject
		{
			string databaseFullPath = @"Assets/" + DatabasePrefs.databaseFolder + "/" + databaseName + ".asset";
			
			T db = AssetDatabase.LoadAssetAtPath<T>(databaseFullPath);
			
			if(db == null)
			{
				if(!AssetDatabase.IsValidFolder(@"Assets/" + DatabasePrefs.databaseFolder))
				{
					AssetDatabase.CreateFolder("Assets", DatabasePrefs.databaseFolder);
				}
				
				db = ScriptableObject.CreateInstance<T>();
				AssetDatabase.CreateAsset(db, databaseFullPath);
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();
				EditorUtility.FocusProjectWindow();
				Selection.activeObject = db;
			}
			
			return db;
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

		[MenuItem("Assets/BZA/Create/Quality Database")]
		public static void CreateItemQualityDatabase()
		{
			CreateAsset<BurgZergArcade.ItemSystem.ItemQualityDatabase>();
		}


	}
}