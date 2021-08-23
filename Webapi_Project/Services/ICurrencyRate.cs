using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Project.Models;

namespace Webapi_Project.Services
{
    public interface ICurrencyRate
    {
        IList<ConversionAmount> GetConversionAmount(List<CurrencyRate> currencyRate);

        IEnumerable<ConversionAmount> GetAmount(List<CurrencyRate> currencyRate);
    }
}
