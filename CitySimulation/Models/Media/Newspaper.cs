namespace CitySimulation.Models.Media
{
    public class Newspaper : MediaBuilding
    {
        public int DailyCirculation { get; set; }

        public Newspaper()
        {
            Name = "Газета";
            MediaType = "Newspaper";
            AudienceCoverage = 10000;
            InfluencePower = 0.5m;
            DailyCirculation = 5000;
        }
    }
}