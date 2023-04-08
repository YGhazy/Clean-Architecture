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
    public class CreateReservationCommand  : ICommand
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Reservation _reservation;

        public CreateReservationCommand(IReservationRepository reservationRepository, IUnitOfWork unitOfWork, Reservation reservation)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
            _reservation = reservation;   
        }

        public bool CanExecute()
        {
            if (_reservation == null)
            {
                return false;
            }
            return true;
        }

        public async Task Execute()
        {
            await _reservationRepository.CreateAsync(_reservation);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Undo()
        {
            await _reservationRepository.RemoveAsync(_reservation);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public class ReservationManager //invoker
    {
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();
        public ReservationManager()
        {
        }
        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
                _commands.Push(command);
            }
        }

        public void Undo()
        {
            if (_commands.Any())
            {
                _commands.Pop()?.Undo();
            }
        }

        public void UndoAll()
        {
            while (_commands.Any())
            {
                _commands.Pop()?.Undo();
            }
        }
    }
}

