using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.RabitMQ
{
    public class RabbitMQMessage
    {
        Guid UserId { get; set; }
        string TemplateName { get; set; }
        List<string> Tokens { get; set;}
    }
}
