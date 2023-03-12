using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IPaymentFactory
    {
        IPayment CreatePayment(PaymentMethod paymentMethod);
    }
}
