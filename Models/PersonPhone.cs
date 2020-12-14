using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PersonPhone
    {
        public BusinessEntity BusinessEntity { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
