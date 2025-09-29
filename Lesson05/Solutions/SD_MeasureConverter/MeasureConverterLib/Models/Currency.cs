using DotNetEnv;
using MeasureConverterLib.Services;
using MeasureConverterLib.Services.Interface;

namespace MeasureConverterLib.Models
{
    public class Currency
    {
        private string BaseCurrency { get; }
        private string TargetCurrency { get; }

        private ICurrencyApi CurrencyApi { get; }

        public Currency(string targetCurrency, string baseCurrency = "DKK")
        {
            BaseCurrency = ValidateCurrency(baseCurrency) ?
                baseCurrency.ToUpper() :
                throw new ArgumentException("Base currency must be a valid 3-letter currency code.", nameof(baseCurrency));
            TargetCurrency = ValidateCurrency(targetCurrency) ?
                targetCurrency.ToUpper() :
                throw new ArgumentException("Target currency must be a valid 3-letter currency code.", nameof(targetCurrency));

            Env.TraversePath().Load();
            var apiKey = Environment.GetEnvironmentVariable("APIKEY")!;
            var baseUrl = Environment.GetEnvironmentVariable("BASEURL")!;
            CurrencyApi = new CurrencyApi(new HttpClient(), baseUrl, apiKey);

        }

        public Currency(string targetCurrency, string baseCurrency, ICurrencyApi currencyApi)
        {
            BaseCurrency = ValidateCurrency(baseCurrency) ?
                baseCurrency.ToUpper() :
                throw new ArgumentException("Base currency must be a valid 3-letter currency code.", nameof(baseCurrency));
            TargetCurrency = ValidateCurrency(targetCurrency) ?
                targetCurrency.ToUpper() :
                throw new ArgumentException("Target currency must be a valid 3-letter currency code.", nameof(targetCurrency));
            CurrencyApi = currencyApi ?? throw new ArgumentNullException(nameof(currencyApi));

        }
        public double Convert(double amount)
        {
            if (!double.IsFinite(amount))
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be a finite number.");
            }
            var rate = CurrencyApi.GetExchangeRatesAsync(baseCurrency: BaseCurrency, targetCurrency: TargetCurrency);
            rate.Wait();
            return rate.Result == null ? throw new Exception("Failed to retrieve exchange rate.") : Math.Round(amount * rate.Result.Value, 2);
        }

        private static bool ValidateCurrency(string currency)
        {
            // To be implemented: Validate currency codes against a known list of ISO 4217 codes.

            if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3 || !currency.All(char.IsLetter))
            {
                throw new ArgumentException("Currency must be a valid 3-letter currency code.", nameof(currency));
            }
            return true;
        }

    }
}
