using System;
using DatabaseManagment.Editor;
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
            QualityTab();
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
        /// The Quality tab.
        /// </summary>
        void QualityTab()
        {
            if (tabState == TabState.QUALITY)
                GUILayout.Label("Quality", "Button", GUILayout.ExpandWidth(true));

            // Displays a quality button at the top and if it is clicked edits the qulity database
            else if (GUILayout.Button("Quality", "Box", GUILayout.ExpandWidth(true)))
            {
                tabState = TabState.QUALITY;
                ResetDisplayState();
            }
        }

        void ResetDisplayState()
        {
            weaponDatabase = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>(DatabaseManager.weaponDatabase, "Weapon");
            armorDatabase = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>(DatabaseManager.armorDatabase, "Armor");
            consumableDatabase = new ISObjectDatabaseType<ISConsumableDatabase, ISConsumable>(DatabaseManager.consumableDatabase, "Consumable");
        }
    }//class
}//namespace