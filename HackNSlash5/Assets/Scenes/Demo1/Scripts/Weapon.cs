using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Weapon : MonoBehaviour
{
	public Sprite icon;

	public int itemValue;

	public int burden;

	public Sprite quality;

	public int minDamage;

	public int durability;

	public int maxDurability;

	public BurgZergArcade.ItemSystem.EquipmentSlot equipmentSlot;
}