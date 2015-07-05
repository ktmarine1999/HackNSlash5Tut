using UnityEngine;
using System.Collections;
using UnityEditor;

// Allow an editor class to be initialized when Unity loads without action from the user.
// Note that static constructors with this attribute are called when Unity starts and when Run is pressed. 
// In this second case the Unity runtime is intialised and this is treated as a Load. 
// See the manual page about running editor code on launch for further details.
[InitializeOnLoad]
public class DemoClassTwo
{
	static DemoClassTwo()
	{
		Debug.Log("DemoClassTwo - Winning");
	}

	// Allow an runtime class method to be initialized when Unity game loads runtime without action from the user.
	[RuntimeInitializeOnLoadMethod]
	static void RunMeAtLoadTime()
	{
		Debug.Log("RunMeAtLoadTime - [RuntimeInitializeOnLoadMethod]");
	}

	// Use this for initialization
	void Start()
	{
		Debug.Log("DemoClassTwo - Start");
	}
	
	// Update is called once per frame
	void Update()
	{
		Debug.Log("DemoClassTwo - Update");
	}
}
