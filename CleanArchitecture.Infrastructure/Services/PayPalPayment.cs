using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class PayPalPayment : IPayment
    {
        private readonly ILogging _logging;

        public PayPalPayment()
        {
            _logging = FileLogging.Instance;
        }

        public bool ProcessPayment(decimal amount)
        {
            // Logic to process PayPal payment
            _logging.LogInformation($"Processed PayPal payment for amount {amount}");

            return true;
        }

        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
