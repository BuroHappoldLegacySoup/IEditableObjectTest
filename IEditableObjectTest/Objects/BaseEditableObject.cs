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

            //To maintain UI binding in any parent window, do shallow clone using reflection instead of calling "_object = Clone(_backup)"
            foreach (PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    object? value = prop.GetValue(_backup);
                    prop.SetValue(_object, value);
                }
            }

            //Recreate _backup here so that nested properties of _object are no loner attached to _backup despite the clone above being shallow, 
            _backup = default;// (T)Activator.CreateInstance(typeof(T));
            _isEditing = false;
        }

        private T Clone(T source)
        {
            //Using Json to allow deep cloning objects implementing INotifyPropertyChanged. DeepClone() will fail.
            string jsonString = JsonSerializer.Serialize(source);
            T clone = JsonSerializer.Deserialize<T>(jsonString);
            return clone;
        }

        //private T Clone(T source)
        //{
        //    if (source == null)
        //        return default(T);

        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        DataContractSerializer serializer = new DataContractSerializer(typeof(T));
        //        serializer.WriteObject(memoryStream, source);
        //        memoryStream.Seek(0, SeekOrigin.Begin);
        //        return (T)serializer.ReadObject(memoryStream);
        //    }
        //}
    }
}
