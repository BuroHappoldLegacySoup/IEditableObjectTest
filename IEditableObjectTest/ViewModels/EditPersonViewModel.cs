using IEditableObjectTest.Models;
using IEditableObjectTest.Objects;
using System.Windows.Input;

namespace IEditableObjectTest.ViewModels
{
    public class EditPersonViewModel : BaseNotifyPropertyChanged
    {
        private BaseEditableObject<Person> _editablePerson;

        public Person Person { get; set; }
        public ICommand OkCommand => new RelayCommand(Ok);
        public ICommand CancelCommand => new RelayCommand(Cancel);

        public EditPersonViewModel(Person person)
        {
            Person = person;
            _editablePerson = new BaseEditableObject<Person>(Person);
            _editablePerson.BeginEdit();
        }

        private void Ok()
        {
            _editablePerson.EndEdit();
        }

        private void Cancel()
        {
            _editablePerson.CancelEdit();
        }

    }

}
