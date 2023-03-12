using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepository
{
    public interface ISeatRepository : IAsyncRepository<Seat>
    {
        Task<ICollection<Seat>> GetReservedSeatsByScreenShowIdAsync(int screenShowId);
        Task<IEnumerable<Seat>> GetSeatsByReservationIdAsync(int reservationId);

    }
}
