using System.ComponentModel;

namespace IEditableObjectTest.Models
{
    public class BaseObservableItem : BaseNotifyPropertyChanged
    {
        private bool m_IsSelected;

        private bool m_IsChecked;

        private bool m_IsEnabled;

        [Description("Whether or not this item has been selected in the UI.")]
        public bool IsSelected
        {
            get
            {
                return m_IsSelected;
            }
            set
            {
                SetProperty(ref m_IsSelected, value, "IsSelected");
            }
        }

        [Description("Whether or not this item has been checked in the UI.")]
        public bool IsChecked
        {
            get
            {
                return m_IsChecked;
            }
            set
            {
                SetProperty(ref m_IsChecked, value, "IsChecked");
            }
        }

        [Description("Whether or not this item is enabled in the UI.")]
        public bool IsEnabled
        {
            get
            {
                return m_IsEnabled;
            }
            set
            {
                SetProperty(ref m_IsEnabled, value, "IsEnabled");
            }
        }
    }
}
