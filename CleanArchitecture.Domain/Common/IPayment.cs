﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IPayment
    {
        bool ProcessPayment(decimal amount);
        Task<bool> ProcessPaymentAsync(decimal amount);
    }

}
