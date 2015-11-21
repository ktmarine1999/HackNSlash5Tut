using DatabaseManagment;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
        Sprite _icon;

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

        public override void Clone<T>(T dbObject)
        {
            base.Clone<T>(dbObject);

            ISQuality quality = dbObject as ISQuality;
            _icon = quality._icon;
        }

#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();

            EditorGUILayout.LabelField("***ISQuality Members***");
            _icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
        }
#endif
    }//class
}//namespace