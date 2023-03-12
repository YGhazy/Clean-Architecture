using CleanArchitecture.Domain.Builders;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.States.ReservationState;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ScreenShowId { get; set; }
        public virtual ScreenShow ScreenShow { get; set; }
        public int NumberOfSeats { get; set; }
        public decimal Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<ReservationSeat> ReservationSeats { get; set; }
        public ReservationStateEnum ReservationState { get; set; } // Enum to keep track of the current state

        [NotMapped]
        public IReservationState State // Concrete class that represents the state
        {
            get
            {
                switch (ReservationState)
                {
                    case ReservationStateEnum.Confirmed:
                        return new ConfirmedReservationState();
                    case ReservationStateEnum.CanceledByCinema:
                        return new CancelledByCinemaReservationState();
                    case ReservationStateEnum.CanceledByCustomer:
                        return new CancelledByCustomerReservationState();
                    default:
                        return new PendingReservationState(); // Default to "pending" state
                }
            }
            set { }
        }

        public Reservation()
        {
            State = new PendingReservationState(); // Initialize the state to "pending"
        }

        // Methods to transition the reservation to different states
        public void Confirm()
        {
            State.Confirm(this);
            ReservationState = ReservationStateEnum.Confirmed; 
        }

        public void CancelByCinema()
        {
            State.CancelByCinema(this);
            ReservationState = ReservationStateEnum.CanceledByCinema; 
        }
        public void CancelByCustomer()
        {
            State.CancelByCustomer(this);
            ReservationState = ReservationStateEnum.CanceledByCustomer;
        }


        // Public factory method that returns a builder instance
        public static ReservationBuilder Builder()
        {
            return new ReservationBuilder();
        }

    }
}
