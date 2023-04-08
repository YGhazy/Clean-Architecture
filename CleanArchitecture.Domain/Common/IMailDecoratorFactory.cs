using CleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public interface IMailServiceFactory
    {
        IMailService CreateMailService(MailMethod mailMethod);
    }

    public interface IMailWrapDecoratorFactory
    {
        IMailService CreateDecoratedMailService(DecoratorMethod DecoratorMethod, IMailService mailService);
    }
}
