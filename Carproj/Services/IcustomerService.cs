﻿using Carproj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carproj.Services
{
    internal interface IcustomerService
    {
        void AddCustomer();
        List<Customer> ListCustomer();
    }
}
