using System;
using System.Net;
using System.Threading.Tasks;
using BPAgency.Tests.HttpClients;
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
    }
}