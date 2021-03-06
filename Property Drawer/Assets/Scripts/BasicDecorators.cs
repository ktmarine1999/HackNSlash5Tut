﻿using UnityEngine;
using System.Collections;

public class BasicDecorators : MonoBehaviour
{
	// Attribute used to Force Unity to serialize a private field.
	// Serialized fields also show up in the inspector in Unity
	[SerializeField]
	private string
		myName = "Name Me";

	// Makes a variable not show up in the inspector but be serialized.
	[HideInInspector]
	public string
		desc = "Here is a public string that I want to hide in the inspector.";

	// Attribute to make a string be edited with a height-flexible and scrollable text area.
	// You can specify the minimum and maximum lines for the TextArea, 
	// and the field will expand according to the size of the text.
	// A scrollbar will appear if the text is bigger than the area available.
	[TextArea(3, 5)]
	public string
		editBox = "";

	// Attribute to make a string be edited with a multi-line textfield.	
	[Multiline]
	public string
		editBox2 = "";

	const float minHealth = 0f;
	const float maxHealth = 200f;

	// Attribute used to make a float or int variable in a script be restricted to a specific range.
	// When this attribute is used, the float or int will be shown as a slider in the Inspector instead of the default number field.
	[Range(minHealth, maxHealth)]
	public int
		health;

	// Use this PropertyAttribute to add a header above some fields in the Inspector.
	// The header is done using a DecoratorDrawer.
	[Header("Currency")]
	public int
		gold;
	public int silver;
	public int copper;

	// Use this PropertyAttribute to add a header above some fields in the Inspector.
	// The header is done using a DecoratorDrawer.
	[Header("Stats")]
	public int
		strength;
	public int dexterity;
	public int constitution;

	// Use this PropertyAttribute to add some spacing in the Inspector.
	// The spacing is done using a DecoratorDrawer.
	[Space(15)]
	public string
		race;
	public int age;

	// Specify a tooltip for a field.
	[Space(15)]
	[Tooltip("This is the objects position in the game world")]
	public Vector3
		vec3;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
