using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Services.MailerService;
using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services.MailerService
{
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            FileLogging.Instance.LogInformation($"Message \"{message}\" " +
                $"sent via {nameof(OnPremiseMailService)}.");
            return true;
        }
    }
}
