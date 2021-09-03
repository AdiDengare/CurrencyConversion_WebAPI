using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Webapi_Project.Models;
using Webapi_Project.Services;

namespace Webapi_Project.Services
{
    public class CurrencyConversionService : ICurrencyService
    {
        public async Task<ExchangeRate> GetExchangeRate(string fromCurrency, string toCurrency)
        {
            ExchangeRate exchangeRate = new ExchangeRate();
            string urlString = "https://v6.exchangerate-api.com/v6/1ae2a1a979a46aceb87625fe/latest/" + fromCurrency;
            var webClient = new WebClient();
            var responsejson =  await webClient.DownloadStringTaskAsync(urlString);
            ExchangeRateApiResponse conversionRateApi = JsonConvert.DeserializeObject<ExchangeRateApiResponse>(responsejson);
            ConversionRates conversionRates = conversionRateApi.conversion_rates;
            var currencyConvertTo = toCurrency;
            var getApiInfo = conversionRates.GetType().GetProperty(currencyConvertTo);
            var getRate = getApiInfo.GetValue(conversionRates, null);
            string rateValue = getRate.ToString();
            double amountConvert = Convert.ToDouble(rateValue);
            exchangeRate.From = fromCurrency;
            exchangeRate.To = toCurrency;
            exchangeRate.ConvertedRate = amountConvert;
            return exchangeRate;
        }
    }
}

