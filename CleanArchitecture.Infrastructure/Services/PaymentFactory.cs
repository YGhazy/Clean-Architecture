using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Infrastructure.Services
{
    public class PaymentFactory: IPaymentFactory
    {
        public PaymentFactory()
        {}

        public IPayment CreatePayment(PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.CreditCard:
                    //return _creditCardPayment;
                    return new CreditCardPayment(); ;
                case PaymentMethod.PayPal:
                    //return _payPalPayment;
                    return new PayPalPayment(); ;
                case PaymentMethod.Bitcoin:
                    return new BitcoinPayment();
                default:
                    throw new ArgumentException("Invalid payment method.");
            }
        }
    }
}
