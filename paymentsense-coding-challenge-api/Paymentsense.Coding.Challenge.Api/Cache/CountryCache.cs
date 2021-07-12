using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Paymentsense.Coding.Challenge.Api.Cache
{
    public class CountryCache : ICountryCache
    {
        //TODO: wanted to make it dictionary, but running out of time
        private static IList<Country> Countries { get; set; } = new List<Country>();
        private static readonly object CountriesLock = new object();
        private bool _countriesLoaded = false;
        public bool IsLoaded => _countriesLoaded;

        public async Task<IList<Country>> GetCountries()
        {
            lock (CountriesLock)
            {
                return Countries;
            }
        }

        public Country GetCountryDetails(string name)
        {
            return Countries.FirstOrDefault(x => x.Name == name);
        }

        public bool LoadAllCountries(IList<Country> countries)
        {
            lock (CountriesLock)
            {
                Countries = countries;
                _countriesLoaded = true;
            }
            return true;
        }

        public Country AddCountry(Country country)
        {
            lock (CountriesLock)
            {
                Countries.Add(country);
            }
            return country;
        }
    }
}
