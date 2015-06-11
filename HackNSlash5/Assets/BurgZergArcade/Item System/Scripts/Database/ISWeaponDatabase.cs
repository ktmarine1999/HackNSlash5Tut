using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
	[CreateAssetMenu(fileName = "ISWeaponDatabase", menuName = "Item System/Weapon Database", order = 1000)]
	public class   ISWeaponDatabase : ScriptableObjectDatabase<ISWeapon>
	{
		
	}
}