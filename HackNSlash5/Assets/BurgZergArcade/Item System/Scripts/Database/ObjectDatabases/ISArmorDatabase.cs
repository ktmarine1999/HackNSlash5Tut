using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [CreateAssetMenu(fileName = "ISArmorDatabase", menuName = "Item System/Armor Database", order = 1000)]
    public class ISArmorDatabase : ScriptableObjectDatabase<ISArmor>
    {

    }
}