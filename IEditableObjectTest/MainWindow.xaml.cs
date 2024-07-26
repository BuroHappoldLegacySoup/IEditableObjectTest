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
            ParameterMappingItem? item = m_ViewModel.MappingItems.FirstOrDefault(x => x.IsSelected);
            if (item == null)
                return;

            EditMappingItemView editWindow = new EditMappingItemView(item);
            editWindow.Owner = this;
            editWindow.ShowDialog();
        }
    }
}