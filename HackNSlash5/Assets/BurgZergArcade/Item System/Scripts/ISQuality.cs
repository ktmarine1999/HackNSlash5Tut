using DatabaseManagment;
using UnityEngine;

namespace BurgZergArcade.ItemSystem
{
    [System.Serializable]
    public class ISQuality : DatabaseObject, IISQuality
    {
        /// <summary>
		/// The icon representation of the qulity.
		/// </summary>
		[SerializeField]
        Sprite
            _icon;

        #region IISQuality implementation
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon representation of the qulity.</value>
        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        #endregion

        public ISQuality()
        {
            _name = string.Empty;
            _icon = new Sprite();
        }

        public ISQuality(string name, Sprite sprite)
        {
            _name = name;
            _icon = sprite;
        }//ISQuality
    }//class
}//namespace