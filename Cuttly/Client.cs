using Cuttly.Responses;
using Cuttly.Responses.Enums;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cuttly
{
    public class Client
    {
        private readonly CuttlyOptions _options;
        private readonly HttpClient _httpClient;

        public Client(IOptions<CuttlyOptions> configuration, HttpClient httpClient)
        {
            _options = configuration.Value ?? throw new ArgumentNullException(nameof(configuration));

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress = new Uri(_options.ApiBaseAddress ?? "https://cutt.ly/api/api.php");

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ShortResponse> Shorten(string urlToShorten)
        {
            string urlParameters = $"?key={_options.ApiKey}&short={urlToShorten}";

            var responseMessage = await _httpClient.GetAsync(urlParameters);

            var cuttlyResponse = JsonSerializer.Deserialize<ShortResponse>(await responseMessage.Content.ReadAsStringAsync()) ?? new ShortResponse();

            return cuttlyResponse;
        }
    }
}
