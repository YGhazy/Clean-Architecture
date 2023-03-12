
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class ReservationSeatRepository : BaseRepository<ReservationSeat>, IReservationSeatRepository
    {
        private readonly DatabaseContext _dbContext;
        public ReservationSeatRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
