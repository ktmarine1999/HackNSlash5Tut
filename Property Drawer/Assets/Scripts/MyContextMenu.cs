﻿using UnityEngine;
using System.Collections;

/// <summary>
/// The ContextMenu attribute allows you to add commands to the context menu.
/// In the inspector of the attached script. When the user selects the context menu, the function will be executed.
/// This is most useful for automatically setting up scene data from the script. The function has to be non-static.
/// </summary>
public class MyContextMenu : MonoBehaviour
{
	// Use this attribute to add a context menu to a field that calls a named method.
	[ContextMenuItem("Add", "AddMethod", order = 0)]
	[ContextMenuItem("Subtract", "RemoveMethod", order = 1)]
	[ContextMenuItem("Reset", "ResetMethod", order = 2)]
	public int
		lives = 10;

	[ContextMenu("Add A Life")]
	void AddMethod()
	{
		Debug.Log("Add Option of the Context Menu");
		lives++;
	}

	[ContextMenu("Reset Lives")]
	void ResetMethod()
	{
		Debug.Log("Resetting lives to 0");
		lives = 0;
	}

	[ContextMenu("Remove A Life")]
	void RemoveMethod()
	{
		Debug.Log("Remove Option of the Context Menu");
		lives--;
	}
}
