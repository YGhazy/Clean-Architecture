using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.States.ReservationState
{

    public class PendingReservationState : IReservationState
    {
        public void Confirm(Reservation reservation)
        {
            reservation.ReservationState = ReservationStateEnum.Confirmed;
            reservation.State = new ConfirmedReservationState();
        }

        public void CancelByCinema(Reservation reservation)
        {
            reservation.ReservationState = ReservationStateEnum.CanceledByCinema;
            reservation.State = new CancelledByCinemaReservationState();
        }

        public void CancelByCustomer(Reservation reservation)
        {
            reservation.ReservationState = ReservationStateEnum.CanceledByCustomer;
            reservation.State = new CancelledByCustomerReservationState();
        }

        //public void Expire(Reservation reservation)
        //{
        //    reservation.State = new ExpiredReservationState();
        //}

        //public void NoShow(Reservation reservation)
        //{
        //    reservation.State = new NoShowReservationState();
        //}

        //public void CheckIn(Reservation reservation)
        //{
        //    // Cannot check in a pending reservation
        //}
    }
}



