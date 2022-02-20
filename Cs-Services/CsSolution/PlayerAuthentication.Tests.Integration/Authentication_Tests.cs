using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PlayerAuthentication.Tests.Integration
{
    public class Authentication_Tests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly HttpClient _httpClient;

        public Authentication_Tests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }


        [Fact]
        public async Task TestRequest_ReturnOk()
        {
            var response = await _httpClient.GetAsync("/TestRequest");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task InitGuest_ReturnOk()
        {
           
            var content = new FormUrlEncodedContent(new[]
      {
                new KeyValuePair<string, string>("Id", "123123"),
                new KeyValuePair<string, string>("UserName", "moeen"),
                new KeyValuePair<string, string>("seriesid", "dasds"),

            });
            var response = await _httpClient.PostAsync("/InitGuestPlayer",content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task InitGuest_ResponseNotNullOrEmpty()
        {
            var response = await _httpClient.GetAsync("/InitGuestPlayer");
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseString);
            Assert.NotEqual("", responseString);
        }


    }
}
