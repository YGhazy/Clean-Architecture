using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CleanArchitecture.Domain.States.ReservationState
{
    public interface IReservationState
    {
        void Confirm(Reservation reservation);
        void CancelByCinema(Reservation reservation);
        void CancelByCustomer(Reservation reservation);
        //void Expire(Reservation reservation);
        //void NoShow(Reservation reservation);
        //void CheckIn(Reservation reservation);
    }
}
