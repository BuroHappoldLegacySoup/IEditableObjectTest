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
                    Name = "Adam",
                    ParameterPairs = new List<ParameterPairItem>
                    { new ParameterPairItem { SourceParameterName = "P1", TargetParameterName = "P2" }}
                },
                new ParameterMappingItem
                {
                    Name = "Benjamin",
                    ParameterPairs = new List<ParameterPairItem>
                    { new ParameterPairItem { SourceParameterName = "P1", TargetParameterName = "P2" }}
                },
                new ParameterMappingItem
                {
                    Name = "Christian",
                    ParameterPairs = new List<ParameterPairItem>
                    { new ParameterPairItem { SourceParameterName = "P1", TargetParameterName = "P2" }}
                },
            };
        }
    }
}
