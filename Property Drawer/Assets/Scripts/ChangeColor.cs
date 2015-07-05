using UnityEngine;
using System.Collections;

// Makes a script execute in edit mode.
// By default, script components are only executed in play mode. By adding this attribute,
// each script component will also have its callback functions executed while the Editor is not in playmode.
// The functions are not called constantly like they are in play mode.
// - Update is only called when something in the scene changed.
// - OnGUI is called when the Game View recieves an Event.
// - OnRenderObject and the other rendering callback functions are called on every repaint of the Scene View or Game View.
[ExecuteInEditMode]
public class ChangeColor : MonoBehaviour
{
	void Update()
	{
		gameObject.GetComponent<Renderer>().sharedMaterial.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
	}
}