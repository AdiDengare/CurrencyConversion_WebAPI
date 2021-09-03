using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Project.Services;

namespace Webapi_Project.Models
{
    public class InMemoryLogger : ILogger
    {
        public void LogData(string req, string res)
        {
            var Id = Guid.NewGuid().ToString();

            Dictionary<string, string> request = new Dictionary<string, string>();
            Dictionary<string, string> response = new Dictionary<string, string>();

            request.Add(Id, req);
            response.Add(Id, res);
        }
    }
}
