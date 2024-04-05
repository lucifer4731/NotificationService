using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Query.NotificationTemplate.GetNotificationTemplateById
{
    public class GetNotificationTemplateByIdQuery : IRequest<GetNotificationTemplateByIdResponse>
    {
        public Guid NotificationTemplateId { get; set; }
    }
}
