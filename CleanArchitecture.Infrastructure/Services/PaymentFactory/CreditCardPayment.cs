﻿using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.Payment
{
    public class CreditCardPayment : IPayment
    {
        //private readonly ILogger<CreditCardPayment> _logger;
        private readonly ILogging _logging;
        public CreditCardPayment()
        {
            _logging = FileLogging.Instance;

        }

        public bool ProcessPayment(decimal amount)
        {
            // Logic to process credit card payment
            _logging.LogInformation($"Processed credit card payment for amount {amount}");

            return true;
        }

        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
