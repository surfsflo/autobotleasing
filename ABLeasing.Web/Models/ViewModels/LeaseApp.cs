﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.ViewModels
{
    public class LeaseApp
    {
        public Equipment Equipment { get; set; }
        public Lease Lease { get; set; }
    }
}