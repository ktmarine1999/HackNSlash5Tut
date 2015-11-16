using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [CreateAssetMenu(fileName = "ISObjectDatabase", menuName = "Item System/Object Database", order = 1000)]
    public class ISObjectDatabase : ScriptableObjectDatabase<ISObject>
    {

    }
}