using CitySimulation.Models.Base;

namespace CitySimulation.Models.Media
{
    public class MediaBuilding : Building
    {
        public string MediaType { get; set; }
        public int AudienceCoverage { get; set; } // охват аудитории
        public decimal InfluencePower { get; set; } // сила влияния
        public bool IsActive { get; set; } = true;

        public MediaBuilding()
        {
            Name = "Медиа здание";
        }

        public virtual decimal CalculateInfluence()
        {
            return IsActive ? InfluencePower : 0;
        }

        public virtual int CalculateMigrationImpact()
        {
            return IsActive ? AudienceCoverage / 1000 : 0; // упрощенная формула
        }
    }
}