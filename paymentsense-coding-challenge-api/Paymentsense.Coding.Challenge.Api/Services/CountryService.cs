using Paymentsense.Coding.Challenge.Api.Cache;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryApiClient _countryApiClient;
        private readonly ICountryCache _cache;
        public CountryService(ICountryApiClient countryApiClient, ICountryCache cache)
        {
            _countryApiClient = countryApiClient;
            _cache = cache;
        }

        public async Task<IList<Country>> GetCountries()
        {
            if (_cache.IsLoaded)
            {
                return await _cache.GetCountries();
            }
            else
            {
                var loadedCountries = await _countryApiClient.GetCountries();

                _cache.LoadAllCountries(loadedCountries);

                return loadedCountries;
            }
        }

        public async Task<IList<Country>> GetCountryDetails(string name)
        {
            return await _countryApiClient.GetCountryDetails(name);
        }

        public Country PostCountry(Country country)
        {
            return _cache.AddCountry(country);
        }
    }
}
