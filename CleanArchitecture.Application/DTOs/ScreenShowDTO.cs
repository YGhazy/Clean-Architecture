using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class ScreenShowDTO
    {
        public int Id { get; set; }
        public int ScreenId { get; set; }
        public virtual ScreenDTO Screen { get; set; }
        public int ShowId { get; set; }
        public virtual ShowDTO Show { get; set; }
        public int AvailableSeats { get; set; }

        public virtual ICollection<ReservationDTO> Reservations { get; set; }
    }
}
