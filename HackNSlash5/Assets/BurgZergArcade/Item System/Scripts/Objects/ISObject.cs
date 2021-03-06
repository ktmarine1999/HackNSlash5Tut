using DatabaseManagment;
using DatabaseManagment.Editor;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [System.Serializable]
    public class ISObject : DatabaseObject, IISObject
    {
        #region IISObject
        /// <summary>
        /// The gold value of the Item.
        /// </summary>
        [SerializeField]
        int _value;

        /// <summary>
        /// The icon to use to display the Item.
        /// </summary>
        [SerializeField]
        Sprite _icon;

        /// <summary>
        /// How much of a burden is this Item on the player.
        /// </summary>
        [SerializeField]
        int _burden;

        /// <summary>
        /// The quality of the Item
        /// </summary>
        [SerializeField]
        ISQuality _quality;
        #endregion

        #region IISObject implementation
        /// <summary>
        /// Gets or sets the Item value.
        /// </summary>
        /// <value>The gold value of the Item.</value>
        public int itemValue
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Gets or sets the Item icon.
        /// </summary>
        /// <value>The icon to use to display the Item.</value>
        public Sprite icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        /// <summary>
        /// Gets or sets the Items burden.
        /// </summary>
        /// <value>How much of a burden is this Item on the player.</value>
        public int burden
        {
            get { return _burden; }
            set { _burden = value; }
        }

        /// <summary>
        /// Gets or sets the Item quality.
        /// </summary>
        /// <value>The quality of the Item</value>
        public ISQuality quality
        {
            get { return _quality; }
            set { _quality = value; }
        }
        #endregion

        public ISObject()
        {
            // DatabaseManagment/DatabaseObject
            _name = "New Item";

            _value = 0;
            _icon = new Sprite();
            _burden = 1;
        }//ISObject

        public override void Clone<T>(T dbObject)
        {
            base.Clone<T>(dbObject);

            ISObject isObject = dbObject as ISObject;
            _value = isObject._value;
            _icon = isObject._icon;
            _burden = isObject._burden;
            _quality = isObject._quality;
        }

#if UNITY_EDITOR
        public override void OnGUI()
        {

            base.OnGUI();

            EditorGUILayout.LabelField("***ISObject Members***");
            //Display a filed to edit the value
            _value = EditorGUILayout.IntField("Value", _value);
            // Display the Burden
            _burden = EditorGUILayout.IntField("Burden", _burden);
            //Display the icon
            DisplayIcon();
            // Dispay the quality from the quality database
            DisplayQuality();
            GUILayout.Space(50);
        }//OnGUI

        public void DisplayIcon()
        {
            _icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
        }//DisplayIcon

        public void DisplayQuality()
        {
            int selectedIndex = 0;

            if (_quality != null)
                selectedIndex = DatabaseManager.qualityDatabase.GetIndex(_quality.name);
            else
                selectedIndex = 0;

            selectedIndex = EditorGUILayout.Popup("Quality", selectedIndex, DatabaseManager.qualityNames());

            quality = DatabaseManager.qualityDatabase.Get(selectedIndex);

        }//DisplayQuality
#endif
    }//class
}//namespace