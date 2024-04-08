using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Notifications.SendNotification
{
    public class SendNotificationQuery : INotification
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string TemplateName { get; set; }
        public Dictionary<string,string> ExternalTokens { get; set; }
    }
}
