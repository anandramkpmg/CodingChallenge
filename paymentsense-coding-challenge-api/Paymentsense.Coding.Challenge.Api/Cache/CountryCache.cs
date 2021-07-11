using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Cache
{
    public class CountryCache : ICountryCache
    {
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
