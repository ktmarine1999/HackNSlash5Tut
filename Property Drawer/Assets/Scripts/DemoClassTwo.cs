using UnityEngine;
using System.Collections;

public class DemoClassTwo
{
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
