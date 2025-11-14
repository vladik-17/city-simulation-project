namespace CitySimulation.Models.Commerce
{
    public class Cafe : CommercialBuilding
    {
        public string CuisineType { get; set; }

        public Cafe()
        {
            Name = "Кафе";
            CommercialType = "Food";
            DailyIncome = 300;
            EmployeeCount = 5;
            CuisineType = "Universal";
        }
    }
}