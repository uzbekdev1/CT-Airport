using CT.Common;
using CT.Service.Dto;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CT.Service
{

    public class RestService
    {

        private readonly HttpClient _client;

        public RestService(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Airports are identified by 3-letter IATA code.
        /// </summary>
        /// <param name="code">IATA code.</param>
        /// <returns></returns>
        public virtual async Task<AirportItem> GetAirport(string code)
        {
            var response = await _client.GetAsync($"/airports/{code}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<AirportItem>();
        }

    }

}
