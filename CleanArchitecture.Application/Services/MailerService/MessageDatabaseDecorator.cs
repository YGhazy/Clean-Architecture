using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.MailerService
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
                FileLogging.Instance.LogInformation($"Message \"{message}\" " +
    $"sent and added in DB via {nameof(MessageDatabaseDecorator)}.");
                return true;
            };

            return false;
        }
    }
}
