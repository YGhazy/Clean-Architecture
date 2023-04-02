using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.States.ReservationState
{
    public class CancelledByCinemaReservationState : IReservationState
    {
        public void Confirm(Reservation reservation)
        {
            throw new InvalidOperationException("Cannot confirm a cancelled reservation");

        }

        public void CancelByCinema(Reservation reservation)
         {
            throw new InvalidOperationException("Already cancelled");

        }

        public void CancelByCustomer(Reservation reservation)
        {
            throw new InvalidOperationException("Cannot cancel a cancelled reservation");
        }

        //public void Expire(Reservation reservation)
        //{
        //    throw new InvalidOperationException("Cannot expire a cancelled reservation");
        //}

        //public void NoShow(Reservation reservation)
        //{
        //    throw new InvalidOperationException("Cannot mark as no show a cancelled reservation");
        //}

        //public void CheckIn(Reservation reservation)
        //{
        //    throw new InvalidOperationException("Cannot check in a cancelled reservation");
        //}
    }

}
