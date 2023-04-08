using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public virtual MovieDTO Movie { get; set; }
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }
        public int SeatId { get; set; }
        public virtual SeatDTO Seat { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
