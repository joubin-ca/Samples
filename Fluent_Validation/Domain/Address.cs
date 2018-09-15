using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum AddressType
    {
        Main,
        Secondary
    }

    public class Address
    {
        public AddressType Type { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
}
