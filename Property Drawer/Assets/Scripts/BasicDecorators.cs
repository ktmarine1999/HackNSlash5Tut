using UnityEngine;
using System.Collections;

public class BasicDecorators : MonoBehaviour
{
	// Attribute used to Force Unity to serialize a private field.
	// Serialized fields also show up in the inspector in Unity
	[SerializeField]
	private string
		myName = "Name Me";

	// Attribute used to make a float or int variable in a script be restricted to a specific range.
	// When this attribute is used, the float or int will be shown as a slider in the Inspector instead of the default number field.
	[Range(0, 100)]
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

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
