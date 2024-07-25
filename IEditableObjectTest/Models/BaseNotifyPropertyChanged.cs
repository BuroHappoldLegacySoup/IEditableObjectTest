using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IEditableObjectTest.Models
{
    public class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        [Description("Handler for when the property changes.")]
        public event PropertyChangedEventHandler PropertyChanged;

        [Description("Triggers property changed if it has been set.")]
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            bool result = false;
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(name);
                result = true;
            }

            return result;
        }

        [Description("Invokes action when property is changed.")]
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
