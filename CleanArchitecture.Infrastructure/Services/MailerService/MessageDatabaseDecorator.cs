using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Services.MailerService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.MailerService
{
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();

        public MessageDatabaseDecorator(IMailService mailService)
            : base(mailService)
        { }

        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                // store sent message
                SentMessages.Add(message);
                return true;
            };

            return false;
        }
    }
}
