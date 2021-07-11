using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System.Collections.Generic;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.AspNetCore.Http;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountriesControllerTests
    {
        [Fact]
        public async void GetAllCountries_OnInvoke_ReturnCountries()
        {
            var countriesMock = new List<Country>() { GetTestCountry() };

            var mockCountriesService = new Mock<ICountryService>();
            mockCountriesService.Setup(c => c.GetCountries()).ReturnsAsync(countriesMock);

            var controller = new CountriesController(mockCountriesService.Object);

            var result = (await controller.Get()).Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeOfType<List<Country>>();
            result.Value.Should().Be(countriesMock);
            mockCountriesService.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountry_ByName_ReturnCountry()
        {
            var countriesMock = new List<Country>() { GetTestCountry() };

            var mockCountriesService = new Mock<ICountryService>();
            mockCountriesService.Setup(c => c.GetCountryDetails("England")).ReturnsAsync(countriesMock);

            var controller = new CountriesController(mockCountriesService.Object);

            var result = (await controller.Get("England")).Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeOfType<List<Country>>();
            result.Value.Should().Be(countriesMock);
            mockCountriesService.Verify(c => c.GetCountryDetails("England"), Times.Once);
        }

        [Fact]
        public void PostCountry_OnInvoke_SavesCountry()
        {
            var mockCountriesService = new Mock<ICountryService>();
            var countryToAdd = GetNewCountryToAdd();
            mockCountriesService.Setup(c => c.PostCountry(countryToAdd)).Returns(countryToAdd);

            var controller = new CountriesController(mockCountriesService.Object);

            var result = controller.PostCountry(countryToAdd).Result as OkObjectResult;
            
            result.Value.Should().BeOfType<Country>();
            result.Value.Should().Be(countryToAdd);
            mockCountriesService.Verify(c => c.PostCountry(countryToAdd), Times.Once);
        }

        private Country GetTestCountry()
        {
            return new Country
            {
                Name = "England",
                Flag = "flag",
                Population = 100000,
                Timezones = new[] { "UTC", "UTC+01:00" },
                Languages = new[] { new Language() { Name = "English" } },
                Currencies = new[] { new Currency() { Name = "GBP" } },
                Capital = "London",
                Borders = new[] { "IRL" }
            };
        }

        private Country GetNewCountryToAdd()
        {
            return new Country
            {
                Name = "France",
                Flag = "flag",
                Population = 123456,
                Timezones = new[] { "UTC", "UTC+01:00" },
                Languages = new[] { new Language() { Name = "French" } },
                Currencies = new[] { new Currency() { Name = "Euro" } },
                Capital = "Paris",
                Borders = new[] { "SPN" }
            };
        }
    }
}
