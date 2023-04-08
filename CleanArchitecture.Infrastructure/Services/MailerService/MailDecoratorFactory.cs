using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Infrastructure.Services.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.MailerService
{
    public class MailDecoratorFactory : IMailServiceFactory
    {
        public IMailService CreateMailService(MailMethod mailMethod)
        {
            switch (mailMethod)
            {
                case MailMethod.OnPremise:
                    return new OnPremiseMailService(); ;
                case MailMethod.Cloud:
                    return new CloudMailService(); ;

                default:
                    throw new ArgumentException("Invalid mail type.");
            }
        }
    }

    public class MailWrapDecoratorFactory : IMailWrapDecoratorFactory
    {
        public IMailService CreateDecoratedMailService(DecoratorMethod DecoratorMethod, IMailService mailService)
        {
            switch (DecoratorMethod)
            {
                case DecoratorMethod.MessageDatabase:
                    return new MessageDatabaseDecorator(mailService); ;
                case DecoratorMethod.StatisticsDecorator:
                    return new StatisticsDecorator(mailService); ;

                default:
                    throw new ArgumentException("Invalid decorator.");
            }

        }

    }
}
