using CT.Api;
using CT.Api.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CT.Integration.Test
{

    [TestClass]
    public class AirpotTests
    {

        [TestMethod]
        public async Task Calculation_Distance_Test()
        {
            // Arrange
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                   .UseEnvironment("Testing")
                   .UseStartup<Startup>();
            var expected = 4158;

            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                // Act
                var inputModel = new DistanceInputModel
                {
                    SourceCode = "AMS",
                    TargetCode = "USA"
                };
                var response = await client.PostAsJsonAsync("/api/Airport/CaculateDistance", inputModel);
                var actual = await response.Content.ReadAsAsync<double>();

                // Assert
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(Math.Round(actual), expected);
            }
        }
    }
}
