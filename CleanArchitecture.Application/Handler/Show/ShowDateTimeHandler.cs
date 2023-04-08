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
    public class ShowDateTimeHandler : IHandler<Show>
    {
        private IHandler<Show>? _successor;

        public void Handle(Show Show)
        {
            if (Show.DateTime > DateTime.UtcNow)
            {

                throw new ValidationException(
                    new ValidationResult(
                        "Show Date time must be after today at least",
                        new List<string>() { "LastModified" }), null, null);
            }

            // go to the next handler
            _successor?.Handle(Show);
        }

        public IHandler<Show> SetSuccessor(IHandler<Show> successor)
        {
            _successor = successor;
            return successor;
        }
    }

}
