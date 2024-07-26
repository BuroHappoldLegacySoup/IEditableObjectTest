using IEditableObjectTest.Models;
using IEditableObjectTest.Objects;
using System.Windows.Input;

namespace IEditableObjectTest.ViewModels
{
    public class EditMappingItemViewModel : BaseNotifyPropertyChanged
    {
        private BaseEditableObject<ParameterMappingItem> _editableMappingItem;

        public ParameterMappingItem MappingItem { get; set; }
        public ICommand OkCommand => new RelayCommand(Ok);
        public ICommand CancelCommand => new RelayCommand(Cancel);

        public EditMappingItemViewModel(ParameterMappingItem item)
        {
            MappingItem = item;
            _editableMappingItem = new BaseEditableObject<ParameterMappingItem>(MappingItem);
            _editableMappingItem.BeginEdit();
        }

        private void Ok()
        {
            _editableMappingItem.EndEdit();
        }

        private void Cancel()
        {
            _editableMappingItem.CancelEdit();
        }

    }

}
