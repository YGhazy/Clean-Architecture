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
    public class CreateReservationCommand // : ICommand
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
            await _reservationRepository.AddAsync(_reservation);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Undo()
        {
            await _reservationRepository.DeleteAsync(_reservation);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    class Invoker
    {
        //private Command command;
        //public Invoker(Command command)
        //{
        //    this.command = command;
        //}
        //public void executeCommand()
        //{
        //    this.command.execute();
        //}
        //public void unexecuteCommand()
        //{
        //    this.command.unexecute();
        //}
    }
    public class ReservationManager
    {
        private ICommand _command;
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();
        public ReservationManager(ICommand command)
        {
            _command = command;
        }
        public void Invoke()
        {
            if (_command.CanExecute())
            {
                _command.Execute();
                _commands.Push(_command);
            }
        }

        public void Undo()
        {
            if (_commands.Any())
            {
                _commands.Pop()?.Undo();
            }
        }

        //public void UndoAll()
        //{
        //    while (_commands.Any())
        //    {
        //        _commands.Pop()?.Undo();
        //    }
        //}
    }
}
