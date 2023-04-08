using CleanArchitecture.Domain.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class TheaterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? City { get; set; }
        public virtual ICollection<ScreenDTO> Screens { get; set; }

    }
}
