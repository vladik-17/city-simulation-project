using CitySimulation.Models.Base;

namespace CitySimulation.Models.ResourceProcessing_21
{
    public class ProcessingFacility : Building
    {
        private string _inputResourceType;
        private string _outputMaterialType;
        private double _processingRate;
        private double _efficiency;
        private double _inputStorage;
        private double _outputStorage;
        private double _maxInputStorage;
        private double _maxOutputStorage;

        public string InputResourceType
        {
            get => _inputResourceType;
            set => SetProperty(ref _inputResourceType, value);
        }

        public string OutputMaterialType
        {
            get => _outputMaterialType;
            set => SetProperty(ref _outputMaterialType, value);
        }

        public double ProcessingRate
        {
            get => _processingRate;
            set => SetProperty(ref _processingRate, value);
        }

        public double Efficiency
        {
            get => _efficiency;
            set => SetProperty(ref _efficiency, value);
        }

        public double InputStorage
        {
            get => _inputStorage;
            set => SetProperty(ref _inputStorage, value);
        }

        public double OutputStorage
        {
            get => _outputStorage;
            set => SetProperty(ref _outputStorage, value);
        }

        public double MaxInputStorage
        {
            get => _maxInputStorage;
            set => SetProperty(ref _maxInputStorage, value);
        }

        public double MaxOutputStorage
        {
            get => _maxOutputStorage;
            set => SetProperty(ref _maxOutputStorage, value);
        }
    }
}