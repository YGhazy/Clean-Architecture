using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.MailerService
{
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService)
            : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}.");
            return base.SendMail(message);
        }
    }
}
