using BurgZergArcade.Editor;
using UnityEditor;
using UnityEngine;

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
            if (tabState == TabState.WEAPON)
                GUILayout.Label("Weapons", "Button", GUILayout.ExpandWidth(true));

            // Displays a weapons button at the top and if it is clicked edits the weapons database
            else if (GUILayout.Button("Weapons", "Box", GUILayout.ExpandWidth(true)))
            {
                tabState = TabState.WEAPON;
                ResetDisplayState();
            }
        }//Weapons Tab

        /// <summary>
        /// The Armor tab.
        /// </summary>
        void ArmorTab()
        {
            if (tabState == TabState.ARMOR)
                GUILayout.Label("Armor", "Button", GUILayout.ExpandWidth(true));

            // Displays a Armor button at the top and if it is clicked edits the Armor database
            else if (GUILayout.Button("Armor", "Box", GUILayout.ExpandWidth(true)))
            {
                tabState = TabState.ARMOR;
                ResetDisplayState();
            }
        }//Armor Tab

        /// <summary>
        /// The Consumables tab.
        /// </summary>
        void ConsumableTab()
        {
            if (tabState == TabState.CONSUMABLE)
                GUILayout.Label("Consumables", "Button", GUILayout.ExpandWidth(true));

            // Displays a Consumables button at the top and if it is clicked edits the Consumables database
            else if (GUILayout.Button("Consumables", "Box", GUILayout.ExpandWidth(true)))
            {
                tabState = TabState.CONSUMABLE;
                ResetDisplayState();
            }
        }//Consumables Tab

        /// <summary>
        /// The About tab.
        /// </summary>
        void AboutTab()
        {
            if (tabState == TabState.ABOUT)
                GUILayout.Label("About", "Button", GUILayout.ExpandWidth(true));

            // Displays a About button at the top and if it is clicked displays the about screen
            else if (GUILayout.Button("About", "Box", GUILayout.ExpandWidth(true)))
            {
                tabState = TabState.ABOUT;
                ResetDisplayState();
            }
        }//About Tab

        void ResetDisplayState()
        {
            weaponItem = new ItemObjectCatagory<ISWeapon>(DatabaseManager.weaponDatabase, "Weapon");
            armorItem = new ItemObjectCatagory<ISArmor>(DatabaseManager.armorDatabase, "Armor");
            consumableItem = new ItemObjectCatagory<ISConsumable>(DatabaseManager.consumableDatabase, "Consumable");
        }
    }//class
}//namespace