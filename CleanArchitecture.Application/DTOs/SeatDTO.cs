using CleanArchitecture.Domain.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int ScreenId { get; set; }
        public ScreenDTO Screen { get; set; }
    }
}
