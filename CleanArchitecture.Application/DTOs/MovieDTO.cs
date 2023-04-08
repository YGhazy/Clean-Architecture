using CleanArchitecture.Domain.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int DurationInMinutes { get; set; }
        public  ICollection<ShowDTO> Shows { get; set; }
    }
}
