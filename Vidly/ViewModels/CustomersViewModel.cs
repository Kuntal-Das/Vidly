﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
