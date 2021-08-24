using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi_Project.Models
{
    public class CurrencyRateRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public double amount { get; set; }
    }
}
