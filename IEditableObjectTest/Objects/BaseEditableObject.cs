using IEditableObjectTest.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
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

            _backup = JsonClone(_object);
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
                    object value = prop.GetValue(_backup);
                    prop.SetValue(_object, value);
                }
            }

            //Recreate _backup here so that nested properties of _object are no loner attached to _backup despite the clone above being shallow, 
            _backup = default;// (T)Activator.CreateInstance(typeof(T));
            _isEditing = false;
        }

        private T JsonClone(T source) //works with .Net all versions 
        {
            //Deep cloning objects implementing INotifyPropertyChanged and contains events. DeepClone() will fail.
            string jsonString = JsonSerializer.Serialize(source);
            T clone = JsonSerializer.Deserialize<T>(jsonString);
            return clone;
        }

        //works with .Net Framework only
        //BaseObservableItem needs the [field:NonSerialized] attribute added to public event PropertyChangedEventHandler PropertyChanged;
        //Then classes to be editable needs to have the [Serializable] attribute added once at the class name level.
        private T BinaryFormatterClone(T source)
        {
            //Deep cloning objects implementing INotifyPropertyChanged and contains events. DeepClone() will fail.
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, source);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        //Requires too many attributes on classes
        //private T DataContractClone(T source)
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

        private T ShallowClone(T source)
        {
            T clone = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    object value = prop.GetValue(source);
                    prop.SetValue(clone, value);
                }
            }

            return clone;
        }
    }
}
