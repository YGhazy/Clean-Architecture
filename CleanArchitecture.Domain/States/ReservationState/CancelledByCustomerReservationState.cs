using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.States.ReservationState
{
    public class CancelledByCustomerReservationState : IReservationState
    {
        public void Confirm(Reservation reservation)
        {
            throw new InvalidOperationException("Cannot confirm a cancelled reservation");
        }

        public void CancelByCinema(Reservation reservation)
        {
            throw new InvalidOperationException("Cannot cancel a cancelled reservation");
        }

        public void CancelByCustomer(Reservation reservation)
        {
            throw new InvalidOperationException("Already cancelled");

        }

        //    public void Expire(Reservation reservation)
        //{
        //    // Cannot expire a cancelled reservation
        //}

        //public void NoShow(Reservation reservation)
        //{
        //    // Cannot mark as no show a cancelled reservation
        //}

        //public void CheckIn(Reservation reservation)
        //{
        //    // Cannot check in a cancelled reservation
        //}
    }

}
