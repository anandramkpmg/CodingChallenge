using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countriesService)
        {
            _countryService = countriesService;
        }


        [HttpGet]
        public async Task<ActionResult<IList<Country>>> Get()
        {
            var countries = await _countryService.GetCountries();

            return Ok(countries);
        }

        [HttpGet("{name}")]
        public ActionResult<IList<Country>> Get(string name)
        {
            var countries = new List<Country>();

            countries.Add(_countryService.GetCountryDetails(name));

            return Ok(countries);
        }

        [HttpPost]
        public ActionResult<Country> PostCountry(Country country)
        {
            var postedCountry = _countryService.PostCountry(country);

            return Ok(postedCountry);
        }
    }

}
