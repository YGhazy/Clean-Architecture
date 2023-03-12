using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<ScreenShow> ScreenShows { get; set; }

    }
}
