using MeasureConverterLib.Models;
using MeasureConverterLib.Services;
using MeasureConverterLib.Services.Interface;
using Moq;
using RichardSzalay.MockHttp;

namespace TestMeasureConverterLib.UnitTest
{
    [TestFixture]
    [Category("UnitTest")]
    public class TestCurrency
    {
        private Currency? _currency;
        private CurrencyApi _currencyApi;
        private Mock<ICurrencyApi>? _currencyApiMock;

        [SetUp]
        public void SetUp()
        {
            _currencyApi = new CurrencyApi(
                CreateMockHttpClient(JsonData()),
                "http://fakeapi",
                "fakeapikey");



        }
        [TestCase("DKK", "USD", 0.15)]
        [TestCase("DKK", "EUR", 0.13)]
        [TestCase("DKK", "DKK", 1)]
        public void GetCurrencyAsync_ShouldReturnParsedCurrency(string baseCurrency, string targetCurrency, double expected)
        {
            //act
            var resultTask = _currencyApi.GetExchangeRatesAsync(baseCurrency, targetCurrency);
            resultTask.Wait();
            var result = resultTask.Result;

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result?.Code, Is.EqualTo(targetCurrency));
                Assert.That(result?.Value, Is.EqualTo(expected));
            });
        }

        [TestCase(100, "DKK", "USD", 15.0)]
        [TestCase(200, "DKK", "EUR", 26.0)]
        [TestCase(50, "DKK", "DKK", 50.0)]
        public virtual void Convert_ValidInput_ReturnsExpectedResult(double amount, string baseCurrency, string targetCurrency, double expected)
        {
            // Arrange
            _currencyApiMock = new Mock<ICurrencyApi>(MockBehavior.Strict);
            _currencyApiMock.Setup(api => api.GetExchangeRatesAsync(baseCurrency, targetCurrency))
                .ReturnsAsync(
                    new CurrencyInfo()
                    {
                        Code = targetCurrency,
                        Value = targetCurrency switch
                        {
                            "USD" => 0.15,
                            "EUR" => 0.13,
                            _ => 1
                        }
                    });

            _currency = new Currency(targetCurrency, baseCurrency, _currencyApiMock.Object);
            // Act
            var result = _currency.Convert(amount);
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }





        private static string JsonData()
        {
            return """
                    {
                        "data": {
                            "DKK": { "code": "DKK", "value": 1 },
                            "USD": { "code": "USD", "value": 0.15 },
                            "EUR": { "code": "EUR", "value": 0.13 }
                        }
                    }
                    """;

        }
        private static HttpClient CreateMockHttpClient(string responseContent)
        {
            var handler = new MockHttpMessageHandler();
            handler.When("http://fakeapi")
                .Respond("application/json", responseContent);
            return new HttpClient(handler);
        }
    }
}
