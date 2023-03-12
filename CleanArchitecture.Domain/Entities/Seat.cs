using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ScreenId { get; set; }
        public Screen Screen { get; set; }
        public virtual ICollection<ReservationSeat> ReservationSeats { get; set; }
    }
}
