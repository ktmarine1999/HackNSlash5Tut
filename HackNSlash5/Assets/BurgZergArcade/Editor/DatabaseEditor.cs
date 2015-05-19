using UnityEngine;
using UnityEditor;
using System.IO;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database editor.
	/// A helper class use to load editor windows and scriptable objects.
	/// </summary>
	public static class DatabaseEditor
	{
		/// <summary>
		/// Inits the editor window.
		/// </summary>
		/// <returns>The editor window.</returns>
		/// <param name="minSize">Minimum size.</param>
		/// <param name="title">Title.</param>
		/// <typeparam name="T">The type of editor window to create</typeparam>
		public static EditorWindow InitEditorWindow<T>(Vector2 minSize, string title) where T : EditorWindow
		{
			T window = EditorWindow.GetWindow<T>();
			window.minSize = minSize;
			window.title = title;
			window.Show();

			return window;
		}

		/// <summary>
		/// Inits the editor window.
		/// with a min size of 400, 300 and a title of the type passed in.
		/// </summary>
		/// <returns>The editor window.</returns>
		/// <typeparam name="T">The type of editor window to create.</typeparam>
		public static EditorWindow InitEditorWindow<T>() where T : EditorWindow
		{
			return InitEditorWindow<T>(new Vector2(400, 300), typeof(T).Name);
		}

		public static T InitDatabase<T>(string databaseName) where T : ScriptableObject
		{
			string databaseFullPath = @"Assets/" + DatabaseManager.settings.databaseFolder + "/" + databaseName + ".asset";
			
			T db = AssetDatabase.LoadAssetAtPath<T>(databaseFullPath);
			
			if(db == null)
			{
				if(!AssetDatabase.IsValidFolder(@"Assets/" + DatabaseManager.settings.databaseFolder))
				{
					AssetDatabase.CreateFolder("Assets", DatabaseManager.settings.databaseFolder);
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