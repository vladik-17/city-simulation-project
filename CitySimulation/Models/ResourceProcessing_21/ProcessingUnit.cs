using CitySimulation.Models.Base;

namespace CitySimulation.Models.ResourceProcessing_21
{
    public class ProcessingUnit : ObservableObject
    {
        private string _name;
        private string _unitType;
        private double _capacity;
        private double _currentLoad;
        private bool _isOperational;
        private double _maintenanceCost;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string UnitType
        {
            get => _unitType;
            set => SetProperty(ref _unitType, value);
        }

        public double Capacity
        {
            get => _capacity;
            set => SetProperty(ref _capacity, value);
        }

        public double CurrentLoad
        {
            get => _currentLoad;
            set => SetProperty(ref _currentLoad, value);
        }

        public bool IsOperational
        {
            get => _isOperational;
            set => SetProperty(ref _isOperational, value);
        }

        public double MaintenanceCost
        {
            get => _maintenanceCost;
            set => SetProperty(ref _maintenanceCost, value);
        }
    }
}