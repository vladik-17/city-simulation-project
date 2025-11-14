using CitySimulation.Models.Base;

namespace CitySimulation.Models.Commerce
{
    public class CommercialBuilding : Building
    {
        public string CommercialType { get; set; }
        public decimal DailyIncome { get; set; }
        public int EmployeeCount { get; set; }
        public bool IsOperational { get; set; } = true;

        public CommercialBuilding()
        {
            Name = "Коммерческое здание";
        }

        public virtual decimal CalculateDailyRevenue()
        {
            return IsOperational ? DailyIncome : 0;
        }
    }
}