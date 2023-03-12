using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models
{
    public class CreateReservationRequest
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int ScreenShowId { get; set; }
        public int[] Seats { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardExpiration { get; set; }
        public string CreditCardCvv { get; set; }
    }
}
