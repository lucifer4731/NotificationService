using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Interfaces.SendNotification
{
    public interface ISmtpEmailSender
    {
        Task SendEmailAsync(Guid userId, string template, Dictionary<string,string> tokens);
    }
}
