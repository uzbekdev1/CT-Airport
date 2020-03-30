using CT.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CT.Integration.Test
{
    [TestClass]
    public abstract class IntegrationTestInitializer : WebApplicationFactory<Startup>
    {
        protected HttpClient _client;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
               .UseStartup<Startup>();

            base.ConfigureWebHost(builder);
        }

        [TestInitialize]
        public void Setup()
        { 
            _client = CreateClient();
        }
    }
}
