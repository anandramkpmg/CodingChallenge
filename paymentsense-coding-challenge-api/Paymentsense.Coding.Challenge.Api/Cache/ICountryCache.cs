using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Cache
{
    public interface ICountryCache
    {
        Task<IList<Country>> GetCountries();
        bool LoadAllCountries(IList<Country> countries);
        Country AddCountry(Country country);
        bool IsLoaded { get; }
        Country GetCountryDetails(string name);
    }
}
