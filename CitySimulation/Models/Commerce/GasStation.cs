namespace CitySimulation.Models.Commerce
{
    public class GasStation : CommercialBuilding
    {
        public string FuelType { get; set; }

        public GasStation()
        {
            Name = "Автозаправка";
            CommercialType = "Fuel";
            DailyIncome = 800;
            EmployeeCount = 4;
            FuelType = "Petrol";
        }
    }
}