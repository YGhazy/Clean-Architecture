using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class PaymentFactory: IPaymentFactory
    {
        private readonly CreditCardPayment _creditCardPayment;
        private readonly PayPalPayment _payPalPayment;
        private readonly BitcoinPayment _bitcoinPayment;

        public PaymentFactory(CreditCardPayment creditCardPayment, PayPalPayment payPalPayment, BitcoinPayment bitcoinPayment)
        {
            _creditCardPayment = creditCardPayment;
            _payPalPayment = payPalPayment;
            _bitcoinPayment = bitcoinPayment;
        }

        public IPayment CreatePayment(PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.CreditCard:
                    return _creditCardPayment;
                case PaymentMethod.PayPal:
                    return _payPalPayment;
                case PaymentMethod.Bitcoin:
                    return _bitcoinPayment;
                default:
                    throw new ArgumentException("Invalid payment method.");
            }
        }
    }
}
