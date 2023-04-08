using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using CleanArchitecture.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handler.Shows
{
    public class MovieHandler : IHandler<Show>
    {
        private IHandler<Show>? _successor;

        public void Handle(Show Show)
        {
            if (Show.MovieId == 0)
            {
                throw new ValidationException("show must have movie");
            }

            _successor?.Handle(Show);
        }

        public IHandler<Show> SetSuccessor(IHandler<Show> successor)
        {
            _successor = successor;
            return successor;
        }
    }

}
