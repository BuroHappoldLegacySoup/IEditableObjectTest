namespace IEditableObjectTest.Models
{
    public class MappingItem : BaseObservableItem
    {
        /***************************************************/
        /****            Private properties             ****/
        /***************************************************/

        private string m_Name;

        public virtual string Name
        {
            get { return m_Name; }
            set { SetProperty(ref m_Name, value); }
        }

        /***************************************************/
    }
}
