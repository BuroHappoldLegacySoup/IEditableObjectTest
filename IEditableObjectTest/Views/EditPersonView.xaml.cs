using IEditableObjectTest.Models;
using IEditableObjectTest.ViewModels;
using System.Windows;

namespace IEditableObjectTest.Views
{
    public partial class EditPersonView : Window
    {
        private EditPersonViewModel m_ViewModel;

        public EditPersonView(Person person)
        {
            InitializeComponent();
            m_ViewModel = new EditPersonViewModel(person);
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
