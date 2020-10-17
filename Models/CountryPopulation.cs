namespace RotativaAspNetCoreDemo.Models
{
    public class CountryPopulation
    {
        public CountryPopulation(string country, int population, double percentage)
        {
            Country = country;
            Population = population;
            Percentage = percentage;
        }
        public string Country { get; }
        public int Population { get; }
        public double Percentage { get; }
    }
}