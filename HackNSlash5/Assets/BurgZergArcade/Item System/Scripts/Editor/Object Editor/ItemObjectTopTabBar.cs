using UnityEngine;
using UnityEditor;

namespace BurgZergArcade.ItemSystem.Editor
{
	public partial class ItemObjectEditor
	{
		void TopTabBar()
		{
			// Contain the tab buttons horizontaly in a box style
			EditorGUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			WeaponsTab();
			ArmorTab();
			ConsumableTab();
			AboutTab();
			EditorGUILayout.EndHorizontal();
		}

		/// <summary>
		/// The weapons tab.
		/// </summary>
		void WeaponsTab()
		{
			// Displays a weapons button at the top and if it is clicked edits the weapons database
			if(GUILayout.Button("Weapons"))
			{
                tabState = TabState.WEAPON;
			}
		}//Weapons Tab

		/// <summary>
		/// The Armor tab.
		/// </summary>
		void ArmorTab()
		{
			// Displays a Armor button at the top and if it is clicked edits the Armor database
			if(GUILayout.Button("Armor"))
			{
                tabState = TabState.ARMOR;
			}
		}//Armor Tab

		/// <summary>
		/// The Consumables tab.
		/// </summary>
		void ConsumableTab()
		{
			// Displays a Consumables button at the top and if it is clicked edits the Consumables database
			if(GUILayout.Button("Consumables"))
			{
                tabState = TabState.CONSUMABLE;
			}
		}//Consumables Tab

		/// <summary>
		/// The About tab.
		/// </summary>
		void AboutTab()
		{
			// Displays a About button at the top and if it is clicked displays the about screen
			if(GUILayout.Button("About"))
			{
                tabState = TabState.ABOUT;
			}
		}//About Tab
	}//class
}//namespace