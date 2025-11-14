using System.Windows.Controls;
using CitySimulation.ViewModels.Media;

namespace CitySimulation.Views.Media
{
    public partial class MediaView : UserControl
    {
        public MediaView()
        {
            InitializeComponent();
            DataContext = new MediaViewModel();
        }
    }
}