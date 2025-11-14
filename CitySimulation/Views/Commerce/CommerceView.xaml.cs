using System.Windows.Controls;
using CitySimulation.ViewModels.Commerce;

namespace CitySimulation.Views.Commerce
{
    public partial class CommerceView : UserControl
    {
        public CommerceView()
        {
            InitializeComponent();
            DataContext = new CommerceViewModel();
        }
    }
}