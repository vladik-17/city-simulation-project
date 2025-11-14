namespace CitySimulation.Models.Media
{
    public class Television : MediaBuilding
    {
        public int ChannelCount { get; set; }

        public Television()
        {
            Name = "Телеканал";
            MediaType = "Television";
            AudienceCoverage = 50000;
            InfluencePower = 0.8m;
            ChannelCount = 1;
        }
    }
}