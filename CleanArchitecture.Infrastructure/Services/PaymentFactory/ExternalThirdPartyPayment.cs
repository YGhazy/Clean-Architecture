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
    public class ExternalThirdPartyPayment
    {
        private readonly ILogging _logging;

        public ExternalThirdPartyPayment()
        {
            _logging = FileLogging.Instance;
        }

        public bool ProcessPayment(decimal amount)
        {
            // Process the payment using the new API
            return true;
        }

    }

    public class PaymentGatewayAdapter : ExternalThirdPartyPayment,IPayment
    {
        private readonly ExternalThirdPartyPayment _thirdPartyPayment;

        private readonly ILogging _logging;

        public PaymentGatewayAdapter()
        {
            _logging = FileLogging.Instance;
        }
        public bool ProcessPayment(decimal amount)
        {

            decimal total = ConvertAmount(amount);

            // Call the new payment gateway API
            base.ProcessPayment( total);

            _logging.LogInformation($"Processed payment Gateway Adapter for amount {amount}");

            return true;
        }

        private decimal ConvertAmount(decimal amount)
        {
            // Convert the amount to the new format
            return  amount;

        }


        public Task<bool> ProcessPaymentAsync(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
