﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_access_layer
{
    public class AdminOverTimePay : IOvertimePay
    {
        public int MyOverTimePay(int hour)
        {
            int departmentpay = 400;
            return hour * departmentpay;
        }
    }
}
