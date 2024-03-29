﻿using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class ReservationSeatDTO
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        public virtual SeatDTO Seat { get; set; }
        public int ReservationId { get; set; }
        public virtual ReservationDTO Reservation { get; set; }
    }
}
