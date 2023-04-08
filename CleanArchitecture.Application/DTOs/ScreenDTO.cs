﻿using CleanArchitecture.Domain.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class ScreenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int TheaterId { get; set; }
        public virtual Theater Theater { get; set; }
        public virtual ICollection<SeatDTO> Seats { get; set; }
        public virtual ICollection<ScreenShow> ScreenShows { get; set; }
    }
}
