using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public interface ICountryApiClient
    {
        Task<IList<Country>> GetCountries();

        Task<IList<Country>> GetCountryDetails(string name);
    }
}
