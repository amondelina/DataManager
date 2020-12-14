using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsManager;
using DataAccessLayer;


namespace ServiceLayer
{
    class SendingOptions : Options
    {
        public ConnectionOptions LogOptions { get; set; } = new ConnectionOptions { Database = "Log" };
        public string Directory { get; set; } = @"D:\code\c#\FileWatcherService\bin\Debug\SourceDirectory";
    }
}
