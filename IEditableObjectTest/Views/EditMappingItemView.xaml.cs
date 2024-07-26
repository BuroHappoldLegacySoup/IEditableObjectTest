using IEditableObjectTest.Models;
using IEditableObjectTest.ViewModels;
using System.Windows;

namespace IEditableObjectTest.Views
{
    public partial class EditMappingItemView : Window
    {
        private EditMappingItemViewModel m_ViewModel;

        public EditMappingItemView(ParameterMappingItem item)
        {
            InitializeComponent();
            m_ViewModel = new EditMappingItemViewModel(item);
            DataContext = m_ViewModel;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
