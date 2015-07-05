using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// The MenuItem attribute allows you to add menu items to the main menu and inspector context menus.
/// 
/// The MenuItem attribute turns any static function into a menu command. Only static functions can use the MenuItem attribute.
/// 
/// To create a hotkey you can use the following special characters: 
/// 	% (ctrl on Windows, cmd on OS X), # (shift), & (alt), <b>_</b> (no key modifiers).
/// For example to create a menu with hotkey shift-alt-g use "MyMenu/Do Something #&g". 
/// To create a menu with hotkey g and no key modifiers pressed use "MyMenu/Do Something _g".
/// 
/// Some special keyboard keys are supported as hotkeys, for example "#LEFT" would map to shift-left. 
/// The keys supported like this are: LEFT, RIGHT, UP, DOWN, F1 .. F12, HOME, END, PGUP, PGDN.
/// 
/// A hotkey text must be preceded with a space character
/// 	("MyMenu/Do_g" won't be interpreted as hotkey, while "MyMenu/Do _g" will).
/// 
/// When adding menu items to the "GameObject/" menu for creating custom game objects be sure to call GameObjectUtility.
/// SetParentAndAlign to ensure that the new GameObject is reparented correctly in the case of a context click (see example below). 
/// Your function should also call Undo.RegisterCreatedObjectUndo to make the creation undoable and set 
/// Selection.activeObject to the newly created object. Also note that in order for a menu item in "GameObject/" to be
/// propagated to the hierarchy Create dropdown and hierarchy context menu, it must be grouped with the other 
/// GameObject creation menu items. This can be achieved by setting its priority to 10 (see example below). 
/// Note that for legacy purposes MenuItems in "GameObject/Create Other" with no explicit priority set will receive 
/// a priority of 10 instead of the default 1000 - we encourage using a more descriptive category name than 
/// "Create Other" and explicitly setting the priority to 10.
/// </summary>
public class MyMenuItem : MonoBehaviour
{
	// Add a menu item named "My Custom Menu Item" to BZA/My Custom SubMenu in the menu bar
	// and give it a shortcut (shift ctrl-w on Windows, shift cmd-w on OS X).
	[MenuItem("BZA/My Custom SubMenu/My Custom Menu Item #%w")]
	static void Init()
	{
		Debug.Log("Init was called");
	}

	// Add a menu item called "My Rigidbody Debug" to a Rigidbody's context menu.
	[MenuItem ("CONTEXT/Rigidbody/My Rigidbody Debug")]
	static void RigidbodyDebug()
	{
		Debug.Log("RigidbodyDebug was called on: " + Selection.activeTransform.gameObject.name);
	}

	// Add a menu item to create custom GameObjects.
	// Priority 1 ensures it is grouped with the other menu items of the same kind
	// and propagated to the hierarchy dropdown and hierarch context menus. 
	[MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
	static void CreateCustomGameObject(MenuCommand menuCommand)
	{
		// Create a custom game object
		GameObject go = new GameObject("Custom Game Object");
		// Ensure it gets reparented if this was a context click (otherwise does nothing)
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		// Register the creation in the undo system
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}

}
