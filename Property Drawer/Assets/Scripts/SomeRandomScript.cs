using UnityEngine;
using System.Collections;

// Prevents MonoBehaviour of same type (or subtype) to be added more than once to a GameObject.
[DisallowMultipleComponent]
// The RequireComponent attribute lets automatically add required component as a dependency.
// When you add a script which uses RequireComponent, 
// the required component will automatically be added to the game object.
// This is useful to avoid setup errors.
// For example a script might require that a rigid body is always added to the same game object.
// Using RequireComponent this will be done automatically, thus you can never get the setup wrong.
[RequireComponent(typeof(Rigidbody))]
public class SomeRandomScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
