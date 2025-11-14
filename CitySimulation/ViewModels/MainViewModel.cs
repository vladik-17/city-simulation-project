using CitySimulation.ViewModels.Base;
using CitySimulation.ViewModels.ForeignRelations;
using CitySimulation.ViewModels.EmergencyService;
using CitySimulation.ViewModels.Production_18;
using CitySimulation.ViewModels.ResourceProcessing_21;

namespace CitySimulation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ForeignRelationsViewModel ForeignRelationsVM { get; }
        public EmergencyServiceViewModel EmergencyServiceVM { get; }
        public ProductionViewModel ProductionVM_18 { get; }
        public ResourceProcessingViewModel ResourceProcessingVM_21 { get; }

        public MainViewModel()
        {
            ForeignRelationsVM = new ForeignRelationsViewModel();
            EmergencyServiceVM = new EmergencyServiceViewModel();
            ProductionVM_18 = new ProductionViewModel();
            ResourceProcessingVM_21 = new ResourceProcessingViewModel();
        }
    }
}