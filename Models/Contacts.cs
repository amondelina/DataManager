using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contacts
    {
        public EmailAddress EmailAddress { get; set; }
        public PersonPhone PersonPhone { get; set; }
        public Address Address { get; set; }
    }
}
