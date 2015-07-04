using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BurgZergArcade.ItemSystem
{
	[CreateAssetMenu(fileName = "ISQualityDatabase", menuName = "Item System/Quality Database", order = 1000)]
	public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
	{
		public int GetIndex(string name)
		{
			return database.FindIndex(a => a.Name == name);
		}
	}
}