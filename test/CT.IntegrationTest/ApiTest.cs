using CT.Api;
using CT.Api.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CT.IntegrationTest
{
    [TestClass]
    public class ApiTest : IntegrationTestInitializer
    {
        [TestMethod]
        [DataRow("calc-dist")]
        public async Task Calculation_Distance_Test(string url)
        {
            // Arrange
            var request = $"api/airport/{url}";
            var expected = 4158;

            // Act
            var response = await _client.PostAsJsonAsync(request, new DistanceInputModel
            {
                SourceCode = "AMS",
                TargetCode = "USA"
            });

            // Assert
            var actual = await response.Content.ReadAsAsync<double>();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(Math.Round(actual), expected);

        }
    }
}
