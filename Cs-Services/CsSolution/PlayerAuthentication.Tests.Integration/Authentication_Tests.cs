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
        public async Task TestJwt_ReturnOk()
        {
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("userName", "6212b3dae6f1a74b1457bdca") });
            var response = await _httpClient.PostAsync("/TestJwt", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestJwt_ExpectedValue()
        {

            string key = "userName";
            string value = "6212b3dae6f1a74b1457bdca";

            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>(key, value) });
            var response = await _httpClient.PostAsync("/TestJwt", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseString);
            Assert.Equal(value, responseString);
        }


        [Fact]
        public async Task InitPlayer_ReturnOk_Guest()
        {
            var content = new FormUrlEncodedContent(new[] { 
                new KeyValuePair<string, string>( "guest", "true"),
            new KeyValuePair<string, string>( "serviceId", "6212b3dae6f1a74b1457bdca"),
            new KeyValuePair<string, string>( "authToken", "6212b3dae6f1a74b1457bdca3123214dsads213sa2132dsa13211dasasd321321fdsfsdfds"),
            new KeyValuePair<string, string>( "serviceEmail", "test@email.com"),
            new KeyValuePair<string, string>( "userName", "moeen"),

            });

            var response = await _httpClient.PostAsync("/InitPlayer", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task InitPlayer_ReturnOk_Permanent()
        {
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>( "guest", "false"),
            new KeyValuePair<string, string>( "serviceId", "6212b3dae6f1a74b1457bdca"),
            new KeyValuePair<string, string>( "authToken", "6212b3dae6f1a74b1457bdca3123214dsads213sa2132dsa13211dasasd321321fdsfsdfds"),
            new KeyValuePair<string, string>( "serviceEmail", "test@email.com"),
            new KeyValuePair<string, string>( "userName", "moeen"),
            });

            var response = await _httpClient.PostAsync("/InitPlayer", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task BindService_ReturnOk()
        {
            var content = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>( "serviceId", "6212b3dae6f1a74b1457bdca"),
            new KeyValuePair<string, string>( "authToken", "6212b3dae6f1a74b1457bdca3123214dsads213sa2132dsa13211dasasd321321fdsfsdfds"),
            new KeyValuePair<string, string>( "serviceEmail", "test@email.com"),
            new KeyValuePair<string, string>( "userName", "moeen"),
            });

            var response = await _httpClient.PostAsync("/BindService", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


        }


    }
}
