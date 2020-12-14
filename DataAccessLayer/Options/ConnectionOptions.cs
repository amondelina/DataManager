using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptionsManager;

namespace DataAccessLayer
{
    public class ConnectionOptions:Options
    {
        public string DataSource { get; set; } = @"DESKTOP-7PTBBOD\SQLEXPRESS";
        public string Database { get; set; } = "AdventureWorks2017";
        public string User { get; set; } = @"DESKTOP-7PTBBOD\Lenovo";
        public string Password { get; set; } = "qwerty123";
       // public string AttachDBFileName { get; set; } = @"D:\programs\ms sql\MSSQL14.SQLEXPRESS\MSSQL\DATA\AdventureWorks2017.mdf";
        public bool IntegratedSecurity { get; set; } = true;
    }
}
