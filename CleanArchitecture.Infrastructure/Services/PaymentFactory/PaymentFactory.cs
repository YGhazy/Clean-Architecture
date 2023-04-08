using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Infrastructure.Services.Payment;

namespace CleanArchitecture.Infrastructure.Services.PaymentFactory
{
    public class PaymentFactory : IPaymentFactory
    {
        public PaymentFactory()
        { }

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
                case PaymentMethod.ThirdPartyPayment:
                    return new PaymentGatewayAdapter();
                default:
                    throw new ArgumentException("Invalid payment method.");
            }
        }
    }
}
