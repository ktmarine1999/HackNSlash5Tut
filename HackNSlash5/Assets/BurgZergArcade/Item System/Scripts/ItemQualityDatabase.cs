using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BurgZergArcade.ItemSystem
{
	public class ItemQualityDatabase : ScriptableObject
	{
		public List<ItemQuality> database = new List<ItemQuality>();
	}
}