using IEditableObjectTest.Models;
using System.Collections.ObjectModel;

namespace IEditableObjectTest.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        private ObservableCollection<ParameterMappingItem> _mappingItems;

        public ObservableCollection<ParameterMappingItem> MappingItems
        {
            get { return _mappingItems; }
            set { _mappingItems = value; }
        }

        public MainViewModel()
        {
            MappingItems = new ObservableCollection<ParameterMappingItem>
            {
                new ParameterMappingItem
                {
                    Name = "Mapping 1",
                    ParameterPairs = new List<ParameterPairItem>
                    { new ParameterPairItem { SourceParameterName = "Parameter 1", TargetParameterName = "Parameter 2" }}
                },
                new ParameterMappingItem
                {
                    Name = "Mapping 2",
                    ParameterPairs = new List<ParameterPairItem>
                    { new ParameterPairItem { SourceParameterName = "Parameter 1", TargetParameterName = "Parameter 2" }}
                },
                new ParameterMappingItem
                {
                    Name = "Mapping 3",
                    ParameterPairs = new List<ParameterPairItem>
                    { new ParameterPairItem { SourceParameterName = "Parameter 1", TargetParameterName = "Parameter 2" }}
                },
            };
        }
    }
}
