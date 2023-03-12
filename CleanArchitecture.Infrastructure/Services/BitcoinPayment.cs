using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class BitcoinPayment : IPayment
    {
        private readonly ILogger<BitcoinPayment> _logger;

        public BitcoinPayment(ILogger<BitcoinPayment> logger)
        {
            _logger = logger;
        }

        public bool ProcessPayment(decimal amount)
        {
            // Logic to process credit card payment
            _logger.LogInformation($"Processed credit card payment for amount {amount}");

            return true;
        }

        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
