using System.Collections.ObjectModel;
using CitySimulation.Models.Media;
using CitySimulation.ViewModels.Base;

namespace CitySimulation.ViewModels.Media
{
    public class MediaViewModel : ViewModelBase
    {
        private ObservableCollection<MediaBuilding> _mediaBuildings;
        private decimal _totalInfluence;
        private int _migrationImpact;

        public ObservableCollection<MediaBuilding> MediaBuildings
        {
            get => _mediaBuildings;
            set => SetProperty(ref _mediaBuildings, value);
        }

        public decimal TotalInfluence
        {
            get => _totalInfluence;
            set => SetProperty(ref _totalInfluence, value);
        }

        public int MigrationImpact
        {
            get => _migrationImpact;
            set => SetProperty(ref _migrationImpact, value);
        }

        public MediaViewModel()
        {
            MediaBuildings = new ObservableCollection<MediaBuilding>();
            InitializeDemoData();
        }

        private void InitializeDemoData()
        {
            MediaBuildings.Add(new Television());
            MediaBuildings.Add(new Newspaper());
            MediaBuildings.Add(new SocialNetwork());

            CalculateTotalImpact();
        }

        public void CalculateTotalImpact()
        {
            TotalInfluence = 0;
            MigrationImpact = 0;

            foreach (var media in MediaBuildings)
            {
                TotalInfluence += media.CalculateInfluence();
                MigrationImpact += media.CalculateMigrationImpact();
            }
        }
    }
}