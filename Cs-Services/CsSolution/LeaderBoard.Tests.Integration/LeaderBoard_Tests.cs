using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeaderBoard.Tests.Integration
{
    public class LeaderBoard_Tests : IClassFixture<WebApplicationFactory<Program>>
    {


        private readonly HttpClient _httpClient;

        public LeaderBoard_Tests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }



        [Fact]
        public async Task UpdateLeaderBoardRecord_ReturnOk()
        {

        }

        [Fact]
        public async Task GetLeaderBoardScore_ReturnOk()
        {

        }


        [Fact]
        public async void GetLeaderBoard_ReturnOk()
        {

        }


    }
}
