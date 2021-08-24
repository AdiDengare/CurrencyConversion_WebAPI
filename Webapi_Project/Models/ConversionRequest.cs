using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi_Project.Models
{
    public class ConversionRequest
    {
        public List<CurrencyRateRequest> RateRequests  { get; set; }
    }
}
