using System.Collections.Generic;

namespace IEditableObjectTest.Models
{
    public class ParameterMappingItem : MappingItem
    {
        public virtual List<ParameterPairItem> ParameterPairs { get; set; } = null;
    }
}
