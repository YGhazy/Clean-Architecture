using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Reservations
{
    public class CancelReservationCommand //: ICommand
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelReservationCommand(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        //update status to be cancelled and seats to be added 
        public async Task<Reservation> Execute(Reservation reservation)
        {
            throw new NotImplementedException();

        }

        public Task Execute()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Undo(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task Undo()
        {
            throw new NotImplementedException();
        }
    }
}
