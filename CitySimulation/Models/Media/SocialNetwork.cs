namespace CitySimulation.Models.Media
{
    public class SocialNetwork : MediaBuilding
    {
        public int UserCount { get; set; }

        public SocialNetwork()
        {
            Name = "Соцсеть";
            MediaType = "Social";
            AudienceCoverage = 100000;
            InfluencePower = 0.9m;
            UserCount = 50000;
        }
    }
}