using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmailAddress
    {
        public BusinessEntity BusinessEntity { get; set; }
        public int EmailAddressID { get; set; }
        public string EmailAddress1 { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
