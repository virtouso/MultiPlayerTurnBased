using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace PlayerAuthentication.Tests.Integration
{
    public class HealthCheck_Tests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;


        public HealthCheck_Tests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }


        [Fact]
        public async Task HealthCheck_ReturnOk()
        {
            var response = await _httpClient.GetAsync("/healthCheck");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
