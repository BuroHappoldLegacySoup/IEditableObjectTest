namespace IEditableObjectTest.Models
{
    public class BaseObservableItem : BaseNotifyPropertyChanged
    {
        private bool m_IsSelected;

        private bool m_IsChecked;

        private bool m_IsEnabled;

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
