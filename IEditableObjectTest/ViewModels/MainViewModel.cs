using IEditableObjectTest.Models;
using System.Collections.ObjectModel;

namespace IEditableObjectTest.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        private ObservableCollection<Person> _People;

        public ObservableCollection<Person> People
        {
            get { return _People; }
            set { _People = value; }
        }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>
            {
                new Person { Name = "Adam", Age = 20 },
                new Person { Name = "Benjamin", Age = 30 },
                new Person { Name = "Christian", Age = 40 },
            };
        }
    }
}
