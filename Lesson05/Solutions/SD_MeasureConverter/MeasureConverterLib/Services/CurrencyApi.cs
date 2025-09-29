using MeasureConverterLib.Services.Interface;

namespace MeasureConverterLib.Services
{
    public class CurrencyApi(HttpClient httpClient, string baseUrl, string apiKey) : ICurrencyApi
    {
        private string BaseUrl { get; } = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        private string ApiKey { get; } = apiKey ?? throw new ArgumentNullException(nameof(apiKey));


        public async Task<CurrencyInfo?> GetExchangeRatesAsync(string baseCurrency, string targetCurrency)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}?base_currency={baseCurrency}");
            request.Headers.Add("apikey", ApiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var root = System.Text.Json.JsonDocument.Parse(content).RootElement;

            if (!root.TryGetProperty("data", out var data) ||
                !data.TryGetProperty(targetCurrency, out var currency))
                throw new Exception($" Currency {targetCurrency} not found in response.");

            return System.Text.Json.JsonSerializer.Deserialize<CurrencyInfo>(currency.GetRawText())!;

        }

    }


}