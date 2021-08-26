using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Project.Models;

namespace Webapi_Project.Services
{
    public interface ICurrencyService
    {
        //double ExchangeRateService(string fromCurrency,string toCurrency);

        Task<ExchangeRate> GetExchangeRate(string fromCurrency, string toCurrency);

    }
}
