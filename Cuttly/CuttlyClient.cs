using Cuttly.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Cuttly
{
    public class CuttlyClient
    {
        private readonly CuttlyOptions _options;
        private readonly HttpClient _httpClient;

        [ActivatorUtilitiesConstructor]
        public CuttlyClient(IOptions<CuttlyOptions> options, HttpClient httpClient) : this(options.Value, httpClient)
        {
        }

        public CuttlyClient(CuttlyOptions options, HttpClient? httpClient = null)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));

            _httpClient = httpClient ?? new HttpClient();

            _httpClient.BaseAddress = new Uri(_options.ApiBaseAddress ?? "https://cutt.ly/api/api.php");

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ShortResponse> Shorten(string urlToShorten)
        {
            string urlParameters = $"?key={_options.ApiKey}&short={urlToShorten}";

            var responseMessage = await _httpClient.GetAsync(urlParameters).ConfigureAwait(false);

            var cuttlyResponse = JsonSerializer.Deserialize<ShortResponse>(await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)) ?? new ShortResponse();

            return cuttlyResponse;
        }
    }
}
