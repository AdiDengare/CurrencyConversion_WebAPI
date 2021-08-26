using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Webapi_Project.Models;
using Webapi_Project.Services;

namespace Webapi_Project.Controllers
{
    [ApiController]
    [Route("currencies")]
    public class CurrencyController : Controller
    {

        private readonly ICurrencyService _currency;

        public CurrencyController(ICurrencyService currency)
        {
            _currency = currency;
        }
        
        [HttpPost]
        public ConversionResponse GetExchangeAmount(ConversionRequest conversionRequest)
        {
            ConversionResponse res = new ConversionResponse();
            res.RateResponses = new List<CurrencyRateResponse>();
            List<CurrencyRateRequest> List = conversionRequest.RateRequests;
            do
            {
                
                var splittted = List.Select((v, i) => new { val = v, idx = i })
                                    .GroupBy(x => x.idx / 2)
                                    .Select(g => g.Select(y => y.val).ToList())
                                    .ToList();
                
                foreach (var batchOfThree in splittted)
                {
                    List<Task<ExchangeRate>> tasks = new List<Task<ExchangeRate>>();
                    foreach (var rate in batchOfThree)
                    {
                        var t = _currency.GetExchangeRate(rate.From, rate.To);
                        tasks.Add(t);
                    }
                    
                    Task[] listOfArray = tasks.ToArray();
                    Task.WaitAll(listOfArray);

                    foreach (var item in tasks)
                    {
                        ExchangeRate exgRate = item.Result;

                        var matchReqRate = conversionRequest.RateRequests.Find(x => x.From == exgRate.From && x.To == exgRate.To);
                        var convertedAmount = matchReqRate.Amount * exgRate.ConvertedRate;
                        CurrencyRateResponse rateResponse = new CurrencyRateResponse();
                        rateResponse.From = exgRate.From;
                        rateResponse.To = exgRate.To;
                        rateResponse.Amount = matchReqRate.Amount;
                        rateResponse.ConvertedAmount = matchReqRate.Amount * convertedAmount;
                        res.RateResponses.Add(rateResponse);
                    }
                    
                }
                return res;
            } while (List.Count > 0);
        }
    }
}
