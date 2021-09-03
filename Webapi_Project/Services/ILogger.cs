using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi_Project.Services
{
    public interface ILogger
    {
        void LogData(string req, string res);
    }
}
