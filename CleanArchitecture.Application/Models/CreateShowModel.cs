using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models
{
    public class CreateShowModel
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieId { get; set; }
        public virtual int[] Screens { get; set; }
    }
}
