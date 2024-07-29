namespace IEditableObjectTest.Models
{
    public class MappingItem : BaseObservableItem
    {
        private string m_Name;

        public virtual string Name
        {
            get { return m_Name; }
            set { SetProperty(ref m_Name, value); }
        }
    }
}
