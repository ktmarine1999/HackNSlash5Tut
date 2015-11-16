using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
	[CreateAssetMenu(fileName = "ISQualityDatabase", menuName = "Item System/Quality Database", order = 1000)]
	public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
	{
        /*
         * have a method that checks to see if the database is created
         * If not create it and add one entry
         */

		public int GetIndex(string name)
		{
			return items.FindIndex(a => a.name == name);
		}
	}
}