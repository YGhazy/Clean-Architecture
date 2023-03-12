using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class ScreenShow
    {
        public int Id { get; set; }
        public int ScreenId { get; set; }
        public virtual Screen Screen { get; set; }
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
        public int AvailableSeats { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
