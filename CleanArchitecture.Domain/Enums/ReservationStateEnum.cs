using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Enums
{
    public enum ReservationStateEnum
    {
        Pending,
        Confirmed,
        CanceledByCinema,
        CanceledByCustomer,
        Expired,
        NoShow,
        CheckedIn
    }

}
