using BurgZergArcade.Editor;
using UnityEngine;

namespace BurgZergArcade.ItemSystem.Editor
{
    public partial class ItemObjectCatagory<T> where T : DatabaseObject
    {
        /// <summary>
        /// The temp item to edit the details so the database doesn't get changed until the item is saved.
        /// </summary>
        protected T tempItem;

        /// <summary>
        /// The database that we are working with
        /// </summary>
        protected ScriptableObjectDatabase<T> database;

        /// <summary>
        /// The scroll position.
        /// Used in ListView when display the List;
        /// </summary>
        protected Vector2 listScrollPos = Vector2.zero;

        /// <summary>
        /// The selected index
        /// </summary>
        protected int selectedIndex = -1;

        /// <summary>
        /// The show new details.
        /// </summary>
        protected bool showDetails = false;

        /// <summary>
        /// String that contains the type of Item that's in this database
        /// Used in the button string of the Create Button
        /// </summary>
        protected string itemtype = "Item";

        public ItemObjectCatagory(ScriptableObjectDatabase<T> database, string itemType)
        {
            this.database = database;
            itemtype = itemType;
        }

        /// <summary>
        /// Displays the list view and the details view
        /// </summary>
        public virtual void OnGUI()
        {
            ListView();
            DetailsView();
        }

        /// <summary>
        /// Create a new Item
        /// 
        /// used as a work around for
        /// error CS0304: Cannot create an instance of the variable type 'T' because it doesn't have the new() constraint
        /// tempItem = new T() as T;
        /// 
        /// override this for new typs of items
        /// tempItem = new ItemType() as T;
        /// 
        /// currently handles weapaon, armor, consumable
        /// if(database is ISWeaponDatabase)
        ///  tempItem = new ISWeapon() as T;
        /// </summary>
        virtual protected void CreateNewItem()
        {
            if (database is ISWeaponDatabase)
            {
                tempItem = new ISWeapon() as T;
            }
            else if (database is ISArmorDatabase)
            {
                tempItem = new ISArmor() as T;
            }
            else if (database is ISConsumableDatabase)
            {
                tempItem = new ISConsumable() as T;
            }
        }//CreateItem

        /// <summary>
        /// Clone the Item so we are not working with the copy in the database, in order to save these values have to click save
        /// 
        /// tempObject = new T(database.Get(cnt)) as T;
        /// error CS0304: Cannot create an instance of the variable type 'T' because it doesn't have the new() constraint
        /// error CS1502: The best overloaded method match for `BurgZergArcade.ItemSystem.ISWeapon.ISWeapon(BurgZergArcade.ItemSystem.ISWeapon)' has some invalid arguments
        /// error CS1503: Argument `#1' cannot convert `T' expression to type `BurgZergArcade.ItemSystem.ISWeapon'
        /// workaround
        /// 
        /// override this for new typs of items
        /// tempItem = new ItemType() as T;
        /// 
        /// currently handles weapaon, armor, consumable
        /// if (database is ISWeaponDatabase)
        ///  tempItem = new ISWeapon(DatabaseManager.weaponDatabase.Get(selectedIndex)) as T;
        /// </summary>
        protected virtual void CloneItem()
        {
            if (database is ISWeaponDatabase)
                tempItem = new ISWeapon(DatabaseManager.weaponDatabase.Get(selectedIndex)) as T;
            else if (database is ISArmorDatabase)
                tempItem = new ISArmor(DatabaseManager.armorDatabase.Get(selectedIndex)) as T;
            else if (database is ISConsumableDatabase)
                tempItem = new ISConsumable(DatabaseManager.consumableDatabase.Get(selectedIndex)) as T;
        }//CloneItem
    }
}
