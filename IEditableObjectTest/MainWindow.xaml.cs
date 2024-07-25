using IEditableObjectTest.Models;
using IEditableObjectTest.ViewModels;
using IEditableObjectTest.Views;
using System.Windows;

namespace IEditableObjectTest
{
    public partial class MainWindow : Window
    {
        MainViewModel m_ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            m_ViewModel = new MainViewModel();
            this.DataContext = m_ViewModel;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Person? person = m_ViewModel.People.FirstOrDefault(x => x.IsSelected);
            if (person == null)
                return;

            EditPersonView editWindow = new EditPersonView(person);
            editWindow.Owner = this;
            editWindow.ShowDialog();
        }
    }
}