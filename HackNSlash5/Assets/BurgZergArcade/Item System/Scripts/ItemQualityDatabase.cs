using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BurgZergArcade.ItemSystem
{
	public class ItemQualityDatabase : ScriptableObject
	{
		[SerializeField]
		public List<ItemQuality>
			db = new List<ItemQuality>();
	}
}