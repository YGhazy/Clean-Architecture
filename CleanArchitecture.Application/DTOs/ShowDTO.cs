using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DTOs
{
    public class ShowDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieId { get; set; }
        public virtual MovieDTO Movie { get; set; }
      //  public virtual ICollection<ScreenShow> ScreenShows { get; set; }

    }
}
