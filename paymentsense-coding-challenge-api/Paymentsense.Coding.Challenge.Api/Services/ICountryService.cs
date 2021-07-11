﻿using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface ICountryService
    {
        Task<IList<Country>> GetCountries();

        Task<IList<Country>> GetCountryDetails(string name);

        Country PostCountry(Country country);
    }
}