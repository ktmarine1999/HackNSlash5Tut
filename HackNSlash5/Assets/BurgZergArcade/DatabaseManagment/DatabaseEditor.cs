using UnityEngine;
using UnityEditor;
using System.IO;

namespace BurgZergArcade.Editor
{
	/// <summary>
	/// Database editor.
	/// A helper class use to load editor windows and scriptable objects.
	/// </summary>
	public static partial class DatabaseEditor
	{
		#region Editor window
		/// <summary>
		/// Inits the editor window.
		/// With the user set min size and the user set title.
		/// </summary>
		/// <returns>The editor window.</returns>
		/// <param name="minSize">Minimum size the window can be.</param>
		/// <param name="title">The title of the window.</param>
		/// <typeparam name="T">The type of editor window to create</typeparam>
		public static EditorWindow InitEditorWindow<T>(Vector2 minSize, string title) where T : EditorWindow
		{
			// create a new window of the type passed in
			T window = EditorWindow.GetWindow<T>();
			// set the minimum size of the window to the size passed in
			window.minSize = minSize;
			// set the title of the window to the string passed in
			window.title = title;
			// show the window
			window.Show();
			// return the window just in case you need it.
			return window;
		}// EditorWidow

		/// <summary>
		/// Inits the editor window.
		/// With a min size of 400, 300 and the user set title.
		/// </summary>
		/// <returns>The editor window.</returns>
		/// <typeparam name="T">The type of editor window to create.</typeparam>
		public static EditorWindow InitEditorWindow<T>() where T : EditorWindow
		{
			//return a editor window with a min size of 400, 300 and a title of the type
			return InitEditorWindow<T>(new Vector2(400, 300), typeof(T).Name);
		}//Editor Window

		/// <summary>
		/// Inits the editor window.
		/// With a min size of 400, 300 with a title.
		/// With the user set min size and a title of the type passed in.
		/// </summary>
		/// <returns>The editor window.</returns>
		/// <param name="title">The title of the window.</param>
		/// <typeparam name="T">The type of editor window to create.</typeparam>
		public static EditorWindow InitEditorWindow<T>(string title) where T : EditorWindow
		{
			//return a editor window with a min size of 400, 300 and a title of the string passed in
			return InitEditorWindow<T>(new Vector2(400, 300), title);
		}// EditorWidow

		/// <summary>
		/// Inits the editor window.
		/// </summary>
		/// <returns>The editor window.</returns>
		/// <param name="minSize">Minimum size.</param>
		/// <typeparam name="T">The type of editor window to create.</typeparam>
		public static EditorWindow InitEditorWindow<T>(Vector2 minSize) where T : EditorWindow
		{
			//return a editor window with a min size passed in and a title of the string passed in
			return InitEditorWindow<T>(minSize, typeof(T).Name);
		}// EditorWidow
		#endregion

		/// <summary>
		/// Inits the database.
		/// </summary>
		/// <returns>The database.</returns>
		/// <param name="databaseName">The name of the Database to create.</param>
		/// <typeparam name="T">The scriptable object to create.</typeparam>
		public static T InitDatabase<T>(string databaseName) where T : ScriptableObject
		{
			// set the full path of the scriptable object to load or create
			string databaseFullPath = @"Assets/";

			//Check to make sure that the db Folder is not null or empty
			if(string.IsNullOrEmpty(DatabaseManager.settings.databaseFolder))
				databaseFullPath += databaseName + ".asset";
			else
				databaseFullPath += DatabaseManager.settings.databaseFolder + "/" + databaseName + ".asset";

			// Load the database that was passed in
			T db = AssetDatabase.LoadAssetAtPath<T>(databaseFullPath);

			// If no database was loaded then create it
			if(db == null)
			{
				// Log a message that no database was loaded
				Debug.Log("Failed to load " + databaseFullPath);
				// First check if the database folder is there
				if(!AssetDatabase.IsValidFolder(@"Assets/" + DatabaseManager.settings.databaseFolder))
				{
					// Log a message that the path needs created
					Debug.Log("Path " + @"Assets/" + DatabaseManager.settings.databaseFolder + " is not valid");

					// If not then create the database folder
					AssetDatabase.CreateFolder("Assets", DatabaseManager.settings.databaseFolder);
				}

				// Create a new instance of the database
				db = ScriptableObject.CreateInstance<T>();
				// Create a new database at the location given so we can load it the next time
				AssetDatabase.CreateAsset(db, databaseFullPath);
				// Save the database
				AssetDatabase.SaveAssets();
				// Refresh the AssetDatabase
				AssetDatabase.Refresh();
				//Set the window to to focus on to be the project winodw
				EditorUtility.FocusProjectWindow();
				// select the new created db
				Selection.activeObject = db;
			}
			
			return db;
		}// Init Database
	}//class
}//namespace