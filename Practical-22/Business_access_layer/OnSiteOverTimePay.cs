﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_access_layer
{
    public class OnSiteOverTimePay : IOvertimePay
    {
        public int MyOverTimePay(int hour)
        {
            int departmentpay = 1000;
            return hour * departmentpay;
        }
    }
}
