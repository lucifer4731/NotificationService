using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Command.NotificationTemplate.DeleteNotificationTemplate
{
    public class DeleteNotificationTemplateQuery : IRequest
    {
        public Guid NotificationTemplateId { get; set; }
    }
}
