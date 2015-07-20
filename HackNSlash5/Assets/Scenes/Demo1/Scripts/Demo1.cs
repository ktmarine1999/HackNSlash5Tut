using UnityEngine;
using System.Collections;
using BurgZergArcade.ItemSystem;

[DisallowMultipleComponent]
public class Demo1 : MonoBehaviour
{
	// Connect to the database
	// Spawn from the databasae

	public ISWeaponDatabase database;

	void OnGUI()
	{
		for(int cnt =0; cnt < database.Count; cnt++)
			if(GUILayout.Button("Spawn " + database.Get(cnt).name))
				Spawn(cnt);
	}

	void Spawn(int index)
	{
		// Get the weapon we want to spawn from the database
		ISWeapon isw = database.Get(index);

		// Instantuate the weapon in the game world
		GameObject weaponGO = Instantiate(isw.prefab);
		// Set the gameobjects name
		weaponGO.name = isw.name;
		// Add the Weaopn script
		Weapon weapon = weaponGO.AddComponent<Weapon>();

		// Transfer the values to the game world weapon

		// Set the weapons Icon
		weapon.icon = isw.icon;
		weapon.itemValue = isw.itemValue;
		weapon.burden = isw.burden;
		weapon.quality = isw.quality.Icon;
		weapon.minDamage = isw.minDamage;
		weapon.durability = isw.durability;
		weapon.maxDurability = isw.maxDurability;
		weapon.equipmentSlot = isw.equipmentSlot;
	}
}
