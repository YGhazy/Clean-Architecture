using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Theater
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? City { get; set; }
        public virtual ICollection<Screen> Screens { get; set; }

    }
}
