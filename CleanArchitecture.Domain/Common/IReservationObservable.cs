using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface ICustomObservable<T>
    {
        void AddObserver(ICustomObserver<T> observer);
        void RemoveObserver(ICustomObserver<T> observer);
        public Task NotifyObservers(T reservation);
    }

    public class ReservationObservable : ICustomObservable<Reservation>
    {
        public readonly List<ICustomObserver<Reservation>> _observers = new();

        public void AddObserver(ICustomObserver<Reservation> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ICustomObserver<Reservation> observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyObservers(Reservation reservation)
        {
            foreach (var observer in _observers)
            {
               await observer.Update(reservation);
            }
        }
    }
    public interface ICustomObserver<T>
    {
        Task Update(T model);
    }
}