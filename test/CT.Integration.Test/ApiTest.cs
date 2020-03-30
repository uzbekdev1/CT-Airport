using CT.Api;
using CT.Api.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CT.Integration.Test
{
    [TestClass]
    public class ApiTest : IDisposable
    {
        private TestServer _server;

        [TestInitialize]
        public void Setup()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder();

            webHostBuilder.UseStartup<Startup>();

            _server = new TestServer(webHostBuilder);

        }

        [TestMethod]
        [DataRow("calc-dist")]
        public async Task Calculation_Distance_Test(string url)
        {
            // Arrange
            var request = $"api/airport/{url}";
            var expected = 4158;

            // Act
            var client = _server.CreateClient();
            var response = await client.PostAsJsonAsync(request, new DistanceInputModel
            {
                SourceCode = "AMS",
                TargetCode = "USA"
            });

            // Assert
            var actual = await response.Content.ReadAsAsync<double>();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(Math.Round(actual), expected);

        }

        [TestCleanup]
        public void Dispose()
        {
            _server.Dispose();
        }
    }
}
