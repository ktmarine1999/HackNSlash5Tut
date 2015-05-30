using UnityEngine;
using System.Collections;

namespace BurgZergArcade.ItemSystem
{
	public interface IISStackable
	{
		int MaxStack{ get; }
		int Stack(int amount);
	}
}