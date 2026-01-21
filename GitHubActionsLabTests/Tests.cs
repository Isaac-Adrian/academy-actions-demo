using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GitHubActionsLab.Tests
{
    public class HelloEndpointTests : IClassFixture<WebApplicationFactory<GitHubActionsLab.Program>>
    {
        private readonly HttpClient _client;

        public HelloEndpointTests(WebApplicationFactory<GitHubActionsLab.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task HelloEndpoint_ReturnsExpectedGreeting()
        {
            var response = await _client.GetAsync("/hello");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("Hello, world!");
        }

    }
}
