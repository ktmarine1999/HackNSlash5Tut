using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [CreateAssetMenu(fileName = "ISEquipmentSlotDB", menuName = "Item System/Equipment Slot Database", order = 1000)]
    public class ISEquipmentSlotDatabase : ScriptableObjectDatabase<ISEquipmentSlot>
    {

    }
}