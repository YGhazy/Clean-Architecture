using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class ReservationSeat
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}
