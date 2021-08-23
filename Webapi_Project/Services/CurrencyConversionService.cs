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
    public class CurrencyConversionService : ICurrencyRate
    {
        public IEnumerable<ConversionAmount> GetAmount(List<CurrencyRate> currencyRate)
        {
            List<ConversionAmount> conversionAmounts = new List<ConversionAmount>();
            foreach (var list in currencyRate)
            {

                string urlString = "https://v6.exchangerate-api.com/v6/4cb40d1991f183f57e8b927c/latest/" + list.from;
                var webClient = new WebClient();
                var responsejson = webClient.DownloadString(urlString);
                ExchangeRateApiResponse conversionRateApi = JsonConvert.DeserializeObject<ExchangeRateApiResponse>(responsejson);
                ConversionRates conversionRates = conversionRateApi.conversion_rates;
                var currencyConvertTo = list.to;
                var getApiInfo = conversionRates.GetType().GetProperty(currencyConvertTo);
                var getRate = getApiInfo.GetValue(conversionRates, null);
                string rateValue = getRate.ToString();
                double amountConvert = Convert.ToDouble(rateValue);
                double convertedAmount = amountConvert * list.amount;

                ConversionAmount currencyConversion = new ConversionAmount();
                currencyConversion.from = list.from;
                currencyConversion.to = list.to;
                currencyConversion.amount = list.amount;
                currencyConversion.convertedamount = convertedAmount;
                conversionAmounts.Add(currencyConversion);
            }
            return conversionAmounts;
        }

        //public ConversionAmount GetConversionAmount(List<CurrencyRate> currencyRate)
        //{
        //    try
        //    {
        //        foreach (var list in currencyRate)
        //        {
        //            string urlString = "https://v6.exchangerate-api.com/v6/4cb40d1991f183f57e8b927c/latest/" + list.from;
        //            using (var webClient = new WebClient())
        //            {
        //                var responsejson = webClient.DownloadString(urlString);
        //                ExchangeRateApiResponse conversionRateApi = JsonConvert.DeserializeObject<ExchangeRateApiResponse>(responsejson);
        //                ConversionRates conversionRates = conversionRateApi.conversion_rates;
        //                var currencyConvertTo = list.to;
        //                var getApiInfo = conversionRates.GetType().GetProperty(currencyConvertTo);
        //                var getRate = getApiInfo.GetValue(conversionRates, null);
        //                string rateValue = getRate.ToString();
        //                double amountConvert = Convert.ToDouble(rateValue);
        //                double convertedAmount = amountConvert * list.amount;



        //                ConversionAmount currencyConversion = new ConversionAmount();
        //                currencyConversion.from = list.from;
        //                currencyConversion.to = list.to;
        //                currencyConversion.amount = list.amount;
        //                currencyConversion.convertedamount = convertedAmount;
        //                return currencyConversion;
        //            }
        //        }
        //        return ;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        IList<ConversionAmount> ICurrencyRate.GetConversionAmount(List<CurrencyRate> currencyRate)
        {
            try
            {
                ConversionResponse conversionResponse = new ConversionResponse();
                conversionResponse.conversionAmounts = new List<ConversionAmount>();
                foreach (var list in currencyRate)
                {
                    
                    string urlString = "https://v6.exchangerate-api.com/v6/4cb40d1991f183f57e8b927c/latest/" + list.from;
                    var webClient = new WebClient();
                    var responsejson = webClient.DownloadString(urlString);
                    ExchangeRateApiResponse conversionRateApi = JsonConvert.DeserializeObject<ExchangeRateApiResponse>(responsejson);
                    ConversionRates conversionRates = conversionRateApi.conversion_rates;
                    var currencyConvertTo = list.to;
                    var getApiInfo = conversionRates.GetType().GetProperty(currencyConvertTo);
                    var getRate = getApiInfo.GetValue(conversionRates, null);
                    string rateValue = getRate.ToString();
                    double amountConvert = Convert.ToDouble(rateValue);
                    double convertedAmount = amountConvert * list.amount;
                    
                    ConversionAmount currencyConversion = new ConversionAmount();
                    currencyConversion.from = list.from;
                    currencyConversion.to = list.to;
                    currencyConversion.amount = list.amount;
                    currencyConversion.convertedamount = convertedAmount;
                    conversionResponse.conversionAmounts.Add(currencyConversion);
                }
                return (IList<ConversionAmount>)conversionResponse;
            }
            catch (Exception ex)
            {
                return (IList<ConversionAmount>)ex;
            }
        }
    }
}

