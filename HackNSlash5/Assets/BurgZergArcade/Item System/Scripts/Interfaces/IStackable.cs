using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IStackable
	{
		int MaxStack{ get; }
		int Stack(int amount);
	}
}