using System.Collections.Generic;

namespace RotativaAspNetCoreDemo.Models
{
    public class CountryPopulationViewModel
    {
        public string Source { get; set; }
        public IReadOnlyCollection<CountryPopulation> Results { get; set; }
        public bool ForExport { get; set; }
    }
}