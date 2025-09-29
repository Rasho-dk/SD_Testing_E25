using DotNetEnv;
using MeasureConverterLib.Models;
using MeasureConverterLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMeasureConverterLib.integrationTests
{
    [TestFixture]
    [Category("IntegrationTest")]
    public class TestCurrency
    {

        #region Integration test
        [Test]
        public async Task GetCurrencyAsync_ShouldCallRealApi()
        {
            Env.TraversePath().Load();
            var currencyApi = new CurrencyApi(new HttpClient(),
                Environment.GetEnvironmentVariable("BASEURL")!,
                Environment.GetEnvironmentVariable("APIKEY")!);
            var result = await currencyApi.GetExchangeRatesAsync(baseCurrency: "DKK", targetCurrency: "USD");

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result?.Code, Is.EqualTo("USD"));
                Assert.That(result?.Value, Is.GreaterThan(0));
            });

        }

        //[Test]
        //[TestCase]
        //public void Convert_ValidInput_ReturnsExpectedResult()
        //{
        //    //arrange
        //    _currency = new Currency("USD");
        //    //act
        //    var result = _currency.Convert(100);
        //    //assert
        //    Assert.That(result, Is.EqualTo(15.69));

        //}

        #endregion
    }
}
