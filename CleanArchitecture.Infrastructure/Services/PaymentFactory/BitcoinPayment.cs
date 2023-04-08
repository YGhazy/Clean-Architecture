using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.Payment
{
    public class BitcoinPayment : IPayment
    {
        private readonly ILogging _logging;

        public BitcoinPayment()
        {
            _logging = FileLogging.Instance;
        }

        public bool ProcessPayment(decimal amount)
        {
            // Logic to process Bitcoin payment
            _logging.LogInformation($"Processed Bitcoin payment for amount {amount}");

            return true;
        }

        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
