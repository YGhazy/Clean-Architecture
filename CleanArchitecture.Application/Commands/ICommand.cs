using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands
{
    public interface ICommand
    {
        Task Execute();
        Task Undo();
        bool CanExecute();
    }

    //public interface IBaseCommand
    //{
    //    Task Execute();
    //    Task Undo();
    //    bool CanExecute();
    //}
}
