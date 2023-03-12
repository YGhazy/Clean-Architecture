using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        private readonly DatabaseContext _dbContext;
        public SeatRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Seat>> GetReservedSeatsByScreenShowIdAsync(int screenShowId)
        {
            var seats = await _dbContext.Seats
                                        .Where(s => s.ReservationSeats.Any(rs => rs.Reservation.ScreenShowId == screenShowId))
                                        .ToListAsync();
            return seats;
        }


        public async Task<IEnumerable<Seat>> GetSeatsByReservationIdAsync(int reservationId)
        {
            var reservationSeats = await _dbContext.ReservationSeats.Where(rs => rs.ReservationId == reservationId).ToListAsync();
            var seatIds = reservationSeats.Select(rs => rs.SeatId);
            return await _dbContext.Seats.Where(s => seatIds.Contains(s.Id)).ToListAsync();
        }
    }
}
