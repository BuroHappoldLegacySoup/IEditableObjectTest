namespace IEditableObjectTest.Models
{
    public class ParameterMappingItem : MappingItem
    {
        /***************************************************/
        /****             Public properties             ****/
        /***************************************************/

        public virtual List<ParameterPairItem> ParameterPairs { get; set; } = null;

        /***************************************************/
    }
}
