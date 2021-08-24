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
        public double ExchangeRateService(string fromCurrency, string toCurrency)
        {
            string urlString = "https://v6.exchangerate-api.com/v6/4cb40d1991f183f57e8b927c/latest/" + fromCurrency;
            var webClient = new WebClient();
            var responsejson = webClient.DownloadString(urlString);
            ExchangeRateApiResponse conversionRateApi = JsonConvert.DeserializeObject<ExchangeRateApiResponse>(responsejson);
            ConversionRates conversionRates = conversionRateApi.conversion_rates;
            var currencyConvertTo = toCurrency;
            var getApiInfo = conversionRates.GetType().GetProperty(currencyConvertTo);
            var getRate = getApiInfo.GetValue(conversionRates, null);
            string rateValue = getRate.ToString();
            double amountConvert = Convert.ToDouble(rateValue);
            return amountConvert;
        }
    }
}

