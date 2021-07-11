using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using Xunit;
using Moq;
using FluentAssertions;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Cache;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountryServiceTests
    {

        private async Task<IList<Country>> GetCountryList()
        {
            return new List<Country>();
        }

        [Fact]
        public async void GetAllCountries_InitialLoad_LoadsFromApi()
        {
            var _countriesMock = new List<Country>
            {
                GetTestCountry()
            };

            var mockCountriesApiClient = new Mock<ICountryApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();            
            mockCache.Setup(c => c.GetCountries()).Returns(GetCountryList());

            var countriesService = new CountryService(mockCountriesApiClient.Object, mockCache.Object);

            var result = await countriesService.GetCountries();

            result.Should().BeOfType<List<Country>>();
            result.Should().BeSameAs(_countriesMock);
            mockCountriesApiClient.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountry_ByName_GetsCountry()
        {
            var _countriesMock = new List<Country>
            {
                GetTestCountry()
            };

            var countryName = "England";
            var mockCountriesApiClient = new Mock<ICountryApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountryDetails(countryName)).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(GetCountryList());

            var countriesService = new CountryService(mockCountriesApiClient.Object, mockCache.Object);

            var result = await countriesService.GetCountryDetails(countryName);

            result.Should().BeOfType<List<Country>>();
            result.Should().BeSameAs(_countriesMock);
            mockCountriesApiClient.Verify(c => c.GetCountryDetails(countryName), Times.Once);
        }

        [Fact]
        public async void GetAllCountries_CountriesAlreadyLoaded_CountryLoadedFromCache()
        {
            var _countriesMock = new List<Country>
            {
                GetTestCountry()
            };

            var mockCountriesApiClient = new Mock<ICountryApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(GetCountryList());
            mockCache.Setup(c => c.IsLoaded).Returns(true);

            var countriesService = new CountryService(mockCountriesApiClient.Object, mockCache.Object);

            var result = await countriesService.GetCountries();
            result.Should().BeOfType<List<Country>>();
            mockCountriesApiClient.Verify(c => c.GetCountries(), Times.Never);
            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }

        private Country GetTestCountry()
        {
            return new Country
            {
                Name = "England",
                Flag = "flag",
                Population = 123456,
                Timezones = new[] { "UTC", "UTC+01:00" },
                Languages = new[] { new Language() { Name = "English" } },
                Currencies = new[] { new Currency() { Name = "GBP" } },
                Capital = "London",
                Borders = new[] { "IRL" }
            };
        }
    }
}
