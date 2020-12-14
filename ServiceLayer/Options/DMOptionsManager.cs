using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsManager;
using DataAccessLayer;
using System.IO;
using Parser;

namespace ServiceLayer
{
    class DMOptionsManager:OptionsManager.OptionsManager
    {
        public DMOptionsManager()
        {
            options = new List<Options>
            {
                new SendingOptions(),
                new ConnectionOptions()
            };
            var path = @"D:\code\c#\DataManagerWithFTPServer\appconfig.xml";
            if (File.Exists(path))
                Copy(options[0], new XMLParser(path).Get<SendingOptions>());
            path = @"D:\code\c#\DataManagerWithFTPServer\dbconfig.xml";
            if (File.Exists(path))
                Copy(options[1], new XMLParser(path).Get<ConnectionOptions>());

        }
 
        void Copy<T>(T obj1, T obj2)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                var prop2 = prop.GetValue(obj2);
                if (prop2 != null)
                    prop.SetValue(obj1, prop2);
            }
        }
    }
}
