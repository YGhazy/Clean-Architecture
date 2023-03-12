using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.States.ReservationState
{
    public class ConfirmedReservationState : IReservationState
    {
        public void Confirm(Reservation reservation)
        {
            // Already confirmed
        }

        public void CancelByCinema(Reservation reservation)
        {
            reservation.State = new CancelledByCinemaReservationState();
        }

        public void CancelByCustomer(Reservation reservation)
        {
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
        //    reservation.State = new CheckedInReservationState();
        //}
    }


}
