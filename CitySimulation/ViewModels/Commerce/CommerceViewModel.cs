using System.Collections.ObjectModel;
using CitySimulation.Models.Commerce;
using CitySimulation.ViewModels.Base;

namespace CitySimulation.ViewModels.Commerce
{
    public class CommerceViewModel : ViewModelBase
    {
        private ObservableCollection<CommercialBuilding> _commercialBuildings;
        private decimal _totalDailyRevenue;

        public ObservableCollection<CommercialBuilding> CommercialBuildings
        {
            get => _commercialBuildings;
            set => SetProperty(ref _commercialBuildings, value);
        }

        public decimal TotalDailyRevenue
        {
            get => _totalDailyRevenue;
            set => SetProperty(ref _totalDailyRevenue, value);
        }

        public CommerceViewModel()
        {
            CommercialBuildings = new ObservableCollection<CommercialBuilding>();
            InitializeDemoData();
        }

        private void InitializeDemoData()
        {
            // Добавляем демо-данные
            CommercialBuildings.Add(new Shop());
            CommercialBuildings.Add(new Cafe());
            CommercialBuildings.Add(new GasStation());

            CalculateTotalRevenue();
        }

        public void CalculateTotalRevenue()
        {
            TotalDailyRevenue = 0;
            foreach (var building in CommercialBuildings)
            {
                TotalDailyRevenue += building.CalculateDailyRevenue();
            }
        }
    }
}