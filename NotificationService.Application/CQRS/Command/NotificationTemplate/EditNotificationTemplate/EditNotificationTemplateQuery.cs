using MediatR;
using NotificationService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Command.NotificationTemplate.EditNotificationTemplate
{
    public class EditNotificationTemplateQuery : IRequest
    {
        public NotificationTemplateDtoForEdit NotificationTemplate{ get; set; }
    }
}
