using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public class CountryApiClient : ICountryApiClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public CountryApiClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IList<Country>> GetCountries()
        {
            using var client = _clientFactory.CreateClient();

            var responseStream = client.GetStreamAsync("https://restcountries.eu/rest/v2/all?fields=name;flag;capital");
            return await JsonSerializer.DeserializeAsync<IList<Country>>(await responseStream);
        }

        public async Task<IList<Country>> GetCountryDetails(string name)
        {
            using var client = _clientFactory.CreateClient();

            var responseStream = client.GetStreamAsync("https://restcountries.eu/rest/v2/name/" + name);

            return await JsonSerializer.DeserializeAsync<IList<Country>>(await responseStream);
        }

    }
}
