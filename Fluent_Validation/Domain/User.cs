using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
