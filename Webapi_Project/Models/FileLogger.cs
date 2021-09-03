using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Project.Services;

namespace Webapi_Project.Models
{
    public class FileLogger : ILogger
    {
        public void LogData(string req, string res)
        {
            var Id = Guid.NewGuid().ToString();
            ////string folderPath = @"D:\Projects\Webapi_Project\Webapi_Project\Req and Res Logs";
            //var uniqueFileNameRequest = $@"{Id} Request.txt";
            //var uniqueFileNameResponse = $@"{Id} Response.txt";
            //string path = @"D:\Projects\Webapi_Project\Webapi_Project\LoggerContent.txt";
            //string createFileRequest = uniqueFileNameRequest + req;
            //string createFileResponse = uniqueFileNameResponse + res;
            //File.WriteAllText(path, createFileRequest);
            //File.WriteAllText(path, createFileResponse);
            //using (StreamWriter sw = File.CreateText(path))
            //{
            //    string requestFile = Id + req;
            //    string responseFile = Id + res;
            //    File.WriteAllText(path, requestFile);
            //    File.WriteAllText(path, responseFile);
            //}
            string folderPathRequest = Path.Combine(@"D:\Projects\Webapi_Project\Webapi_Project\Req and Res Logs\", $" Request-{Id}.txt");
            string folderPathResponse = Path.Combine(@"D:\Projects\Webapi_Project\Webapi_Project\Req and Res Logs\", $"Response-{Id}.txt");
            File.WriteAllText(folderPathRequest, req);
            File.WriteAllText(folderPathResponse, res);
        }
    }
}

