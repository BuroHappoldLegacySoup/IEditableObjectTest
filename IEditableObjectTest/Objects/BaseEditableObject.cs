using IEditableObjectTest.Models;
using System.ComponentModel;
using System.Reflection;

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
            if (_isEditing) return;

            _backup = Clone(_object);
            _isEditing = true;
        }

        public void EndEdit()
        {
            if (!_isEditing) return;

            _backup = default;
            _isEditing = false;
        }

        public void CancelEdit()
        {
            if (!_isEditing) return;

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
            T? clone = (T)Activator.CreateInstance(typeof(T));
            foreach (PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    object? value = prop.GetValue(source);
                    prop.SetValue(clone, value);
                }
            }
            return clone;
        }
    }
}
