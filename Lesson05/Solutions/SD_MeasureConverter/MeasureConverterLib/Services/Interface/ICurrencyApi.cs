namespace MeasureConverterLib.Services.Interface
{
    public interface ICurrencyApi
    {
        Task<CurrencyInfo?> GetExchangeRatesAsync(string baseCurrency, string targetCurrency);

    }
}