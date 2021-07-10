using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryApiClient _countryApiClient;
        public CountryService(ICountryApiClient countryApiClient)
        {
            _countryApiClient = countryApiClient;
        }

        public async Task<IList<Country>> GetCountries()
        {
            return await _countryApiClient.GetCountries();
        }

        public async Task<IList<Country>> GetCountryDetails(string name)
        {
            return await _countryApiClient.GetCountryDetails(name);
        }
    }
}
