using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Builders
{
    public class ReservationBuilder
    {
        private Reservation _reservation;

        public ReservationBuilder()
        {
            _reservation = new Reservation();
            _reservation.ReservationState = ReservationStateEnum.Pending;
        }

        public ReservationBuilder WithUser(User user)
        {
            _reservation.UserId = user.Id;
            _reservation.User = user;
            return this;
        }

        public ReservationBuilder WithScreenShow(ScreenShow screenShow)
        {
            _reservation.ScreenShowId = screenShow.Id;
            _reservation.ScreenShow = screenShow;
            //_reservation.Price = screenShow.Price * _reservation.NumberOfSeats;
            return this;
        }

        public ReservationBuilder WithNumberOfSeats(int numberOfSeats)
        {
            _reservation.NumberOfSeats = numberOfSeats;
            //_reservation.Price = _reservation.ScreenShow.Price * numberOfSeats;
            return this;
        }

        public ReservationBuilder WithPaymentMethod(PaymentMethod paymentMethod)
        {
            _reservation.PaymentMethod = paymentMethod;
            return this;
        }

        public Reservation Build()
        {
            return _reservation;
        }
    }

}
