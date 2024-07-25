using IEditableObjectTest.Models;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace IEditableObjectTest.Objects
{
    public class BaseEditableObject<T> : IEditableObject where T : BaseObservableItem
    {
        private T _object;
        private T _backup;
        private bool _isEditing;

        public BaseEditableObject(T obj)
        {
            _object = obj;
        }

        public void BeginEdit()
        {
            if (_isEditing)
                return;

            _backup = Clone(_object);
            _isEditing = true;
        }

        public void EndEdit()
        {
            if (!_isEditing)
                return;

            _backup = default;
            _isEditing = false;
        }

        public void CancelEdit()
        {
            if (!_isEditing)
                return;

            //We would use this in real application if deep cloning from _backup back to _object is required
            //_object = Clone(_backup);
            //Using this shallow clone just to demonstrate Edit/Cancel actions in the UI sincei it maintains UI binding
            foreach (PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    object? value = prop.GetValue(_backup);
                    prop.SetValue(_object, value);
                }
            }

            _backup = default;
            _isEditing = false;
        }

        private T Clone(T source)
        {
            //Using Json to allow deep cloning objects implementing INotifyPropertyChanged. DeepClone() will fail.
            string jsonString = JsonSerializer.Serialize(source);
            T clone = JsonSerializer.Deserialize<T>(jsonString);
            return clone;
        }
    }
}
