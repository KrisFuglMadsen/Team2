﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet_System.Model
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        
        public string Email { get; set; }
        public string AccountNumber { get; set; }


    }
}
