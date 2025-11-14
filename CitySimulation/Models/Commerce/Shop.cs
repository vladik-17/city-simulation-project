namespace CitySimulation.Models.Commerce
{
    public class Shop : CommercialBuilding
    {
        public int CustomerCapacity { get; set; }

        public Shop()
        {
            Name = "Магазин";
            CommercialType = "Retail";
            DailyIncome = 500;
            EmployeeCount = 3;
            CustomerCapacity = 50;
        }
    }
}