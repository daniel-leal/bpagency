using System;
using System.Net;
using System.Threading.Tasks;
using BPAgency.Tests.HttpClients;
using BPAgency.Tests.Models;
using FluentAssertions;
using Refit;
using Xunit;

namespace BPAgency.Tests
{
    public class AgenciesControllerTests
    {
        private readonly IAgencyAPI _agencyAPI;
        private readonly string URL = "http://localhost:5000";

        public AgenciesControllerTests()
        {
            _agencyAPI = RestService.For<IAgencyAPI>(URL);
        }

        [Fact]
        public async Task ShouldReturnAllAgencies()
        {
            var response = await _agencyAPI.GetAllAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnTenAgencies()
        {
            var response = await _agencyAPI.GetOnyTenRecordsAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Count.Should().Be(10);
        }

        [Fact]
        public async Task ShouldReturnAllCapitalAgencies()
        {
            var response = await _agencyAPI.GetAllFromCapitalAsync();

            int acc = 0;
            foreach (var ag in response.Content)
                if (!ag.IsCapital)
                    acc++;

            acc.Should().Be(0);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnAllInlandAgenciesAsync()
        {
            var response = await _agencyAPI.GetAllFromInlandAsync();

            int acc = 0;
            foreach (var ag in response.Content)
                if (!ag.IsCapital)
                    acc++;

            acc.Should().BeGreaterThan(0);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnAllAgenciesAsync()
        {
            var response = await _agencyAPI.GetAllAgenciesAsync();

            int acc = 0;
            foreach (var ag in response.Content)
                if (!ag.IsStation)
                    acc++;

            acc.Should().BeGreaterThan(0);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnAllStationsAsync()
        {
            var response = await _agencyAPI.GetAllStationAsync();

            int acc = 0;
            foreach (var ag in response.Content)
                if (!ag.IsStation)
                    acc++;

            acc.Should().Be(0);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ShouldReturnAgenciesOrderedByDistance()
        {
            var response = await _agencyAPI.GetAllAgenciesAsync();

            response.Content[0].DistanceInKm.Should().BeLessOrEqualTo(response.Content[1].DistanceInKm);
            response.Content[1].DistanceInKm.Should().BeLessOrEqualTo(response.Content[2].DistanceInKm);
            response.Content[2].DistanceInKm.Should().BeLessOrEqualTo(response.Content[3].DistanceInKm);
            response.Content[3].DistanceInKm.Should().BeLessOrEqualTo(response.Content[4].DistanceInKm);
            response.Content[4].DistanceInKm.Should().BeLessOrEqualTo(response.Content[5].DistanceInKm);
            response.Content[5].DistanceInKm.Should().BeLessOrEqualTo(response.Content[6].DistanceInKm);
            response.Content[6].DistanceInKm.Should().BeLessOrEqualTo(response.Content[7].DistanceInKm);
        }

        [Theory]
        [InlineData("11")]
        [InlineData("12")]
        [InlineData("15")]
        [InlineData("1054")]
        public async Task ShouldReturnAgencyOrStationByCode(string code)
        {
            var response = await _agencyAPI.GetByCode(code);

            response.Content.Code.Should().Be(code);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("5")]
        [InlineData("438")]
        [InlineData("227")]
        [InlineData("664")]
        public async Task ShouldNotReturnAgencyOrStationWithInvalidCode(string code)
        {
            var response = await _agencyAPI.GetByCode(code);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}