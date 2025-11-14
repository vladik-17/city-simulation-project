using CitySimulation.Infrastructure;
using CitySimulation.Models.ResourceProcessing_21;
using CitySimulation.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CitySimulation.ViewModels.ResourceProcessing_21
{
    public class ResourceProcessingViewModel : ViewModelBase
    {
        private ObservableCollection<ProcessingFacility> _facilities;
        private ObservableCollection<ProcessingUnit> _processingUnits;
        private ProcessingFacility _selectedFacility;
        private ProcessingUnit _selectedUnit;
        private string _statusMessage;

        private string _newFacilityName;
        private string _newFacilityAddress;
        private string _newFacilityInputResource;
        private string _newFacilityOutputMaterial;
        private double _newFacilityProcessingRate;
        private string _newUnitName;
        private string _newUnitType;
        private double _newUnitCapacity;

        public ResourceProcessingViewModel()
        {
            Facilities = new ObservableCollection<ProcessingFacility>();
            ProcessingUnits = new ObservableCollection<ProcessingUnit>();

            InitializeTestData();

            AddFacilityCommand = new RelayCommand(ExecuteAddFacility, CanAddFacility);
            ProcessResourcesCommand = new RelayCommand(ExecuteProcessResources, CanProcessResources);
            AddUnitCommand = new RelayCommand(ExecuteAddUnit, CanAddUnit);
            ToggleUnitCommand = new RelayCommand(ExecuteToggleUnit, CanToggleUnit);
        }

        private void InitializeTestData()
        {
            Facilities.Add(new ProcessingFacility
            {
                Name = "Нефтеперерабатывающий завод",
                Address = "ул. Промышленная, 25",
                InputResourceType = "Нефть",
                OutputMaterialType = "Бензин",
                ProcessingRate = 1000,
                Efficiency = 0.85,
                InputStorage = 50000,
                OutputStorage = 15000,
                MaxInputStorage = 100000,
                MaxOutputStorage = 30000,
                XCoordinate = 200,
                YCoordinate = 300
            });

            Facilities.Add(new ProcessingFacility
            {
                Name = "Металлургический комбинат",
                Address = "ул. Металлургов, 10",
                InputResourceType = "Железная руда",
                OutputMaterialType = "Сталь",
                ProcessingRate = 500,
                Efficiency = 0.78,
                InputStorage = 25000,
                OutputStorage = 8000,
                MaxInputStorage = 50000,
                MaxOutputStorage = 15000,
                XCoordinate = 350,
                YCoordinate = 250
            });

            ProcessingUnits.Add(new ProcessingUnit
            {
                Name = "Дистилляционная колонна №1",
                UnitType = "Дистилляция",
                Capacity = 500,
                CurrentLoad = 350,
                IsOperational = true,
                MaintenanceCost = 25000
            });

            NewFacilityProcessingRate = 100;
            NewUnitCapacity = 100;
        }

        public ObservableCollection<ProcessingFacility> Facilities { get => _facilities; set => SetProperty(ref _facilities, value); }
        public ObservableCollection<ProcessingUnit> ProcessingUnits { get => _processingUnits; set => SetProperty(ref _processingUnits, value); }
        public ProcessingFacility SelectedFacility { get => _selectedFacility; set => SetProperty(ref _selectedFacility, value); }
        public ProcessingUnit SelectedUnit { get => _selectedUnit; set => SetProperty(ref _selectedUnit, value); }
        public string StatusMessage { get => _statusMessage; set => SetProperty(ref _statusMessage, value); }

        public string NewFacilityName { get => _newFacilityName; set => SetProperty(ref _newFacilityName, value); }
        public string NewFacilityAddress { get => _newFacilityAddress; set => SetProperty(ref _newFacilityAddress, value); }
        public string NewFacilityInputResource { get => _newFacilityInputResource; set => SetProperty(ref _newFacilityInputResource, value); }
        public string NewFacilityOutputMaterial { get => _newFacilityOutputMaterial; set => SetProperty(ref _newFacilityOutputMaterial, value); }
        public double NewFacilityProcessingRate { get => _newFacilityProcessingRate; set => SetProperty(ref _newFacilityProcessingRate, value); }
        public string NewUnitName { get => _newUnitName; set => SetProperty(ref _newUnitName, value); }
        public string NewUnitType { get => _newUnitType; set => SetProperty(ref _newUnitType, value); }
        public double NewUnitCapacity { get => _newUnitCapacity; set => SetProperty(ref _newUnitCapacity, value); }

        public ICommand AddFacilityCommand { get; }
        public ICommand ProcessResourcesCommand { get; }
        public ICommand AddUnitCommand { get; }
        public ICommand ToggleUnitCommand { get; }

        private void ExecuteAddFacility(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewFacilityName) && !string.IsNullOrWhiteSpace(NewFacilityAddress))
            {
                var newFacility = new ProcessingFacility
                {
                    Name = NewFacilityName.Trim(),
                    Address = NewFacilityAddress.Trim(),
                    InputResourceType = NewFacilityInputResource ?? "Сырье",
                    OutputMaterialType = NewFacilityOutputMaterial ?? "Материал",
                    ProcessingRate = NewFacilityProcessingRate,
                    Efficiency = 0.7,
                    InputStorage = NewFacilityProcessingRate * 50,
                    OutputStorage = 0,
                    MaxInputStorage = NewFacilityProcessingRate * 100,
                    MaxOutputStorage = NewFacilityProcessingRate * 30,
                    XCoordinate = Facilities.Count * 120 + 100,
                    YCoordinate = Facilities.Count * 100 + 100
                };

                Facilities.Add(newFacility);
                StatusMessage = $"🏭 Добавлен новый перерабатывающий объект: {newFacility.Name}";

                NewFacilityName = "";
                NewFacilityAddress = "";
            }
            else
            {
                StatusMessage = "❌ Заполните название и адрес объекта";
            }
        }

        private bool CanAddFacility(object parameter) =>
            !string.IsNullOrWhiteSpace(NewFacilityName) && !string.IsNullOrWhiteSpace(NewFacilityAddress);

        private void ExecuteProcessResources(object parameter)
        {
            if (SelectedFacility != null && SelectedFacility.InputStorage > 0)
            {
                double processed = SelectedFacility.ProcessingRate * SelectedFacility.Efficiency;

                if (processed > SelectedFacility.InputStorage)
                    processed = SelectedFacility.InputStorage;

                SelectedFacility.InputStorage -= processed;
                SelectedFacility.OutputStorage += processed;

                StatusMessage = $"⚙️ Переработано {processed:F0} единиц {SelectedFacility.InputResourceType} " +
                              $"в {SelectedFacility.OutputMaterialType} на объекте '{SelectedFacility.Name}'";

                if (SelectedFacility.Efficiency < 0.95)
                    SelectedFacility.Efficiency += 0.01;
            }
            else
            {
                StatusMessage = "❌ Выберите объект с сырьем для переработки";
            }
        }

        private bool CanProcessResources(object parameter) =>
            SelectedFacility != null && SelectedFacility.InputStorage > 0;

        private void ExecuteAddUnit(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewUnitName) && !string.IsNullOrWhiteSpace(NewUnitType))
            {
                var newUnit = new ProcessingUnit
                {
                    Name = NewUnitName.Trim(),
                    UnitType = NewUnitType.Trim(),
                    Capacity = NewUnitCapacity,
                    CurrentLoad = 0,
                    IsOperational = true,
                    MaintenanceCost = NewUnitCapacity * 100
                };

                ProcessingUnits.Add(newUnit);
                StatusMessage = $"🔧 Добавлена новая установка: {newUnit.Name}";

                NewUnitName = "";
                NewUnitType = "";
            }
            else
            {
                StatusMessage = "❌ Заполните название и тип установки";
            }
        }

        private bool CanAddUnit(object parameter) =>
            !string.IsNullOrWhiteSpace(NewUnitName) && !string.IsNullOrWhiteSpace(NewUnitType);

        private void ExecuteToggleUnit(object parameter)
        {
            if (SelectedUnit != null)
            {
                SelectedUnit.IsOperational = !SelectedUnit.IsOperational;
                StatusMessage = $"🔧 Установка '{SelectedUnit.Name}' " +
                              $"{(SelectedUnit.IsOperational ? "ВКЛЮЧЕНА" : "ВЫКЛЮЧЕНА")}";
            }
            else
            {
                StatusMessage = "❌ Выберите установку для управления";
            }
        }

        private bool CanToggleUnit(object parameter) => SelectedUnit != null;
    }
}