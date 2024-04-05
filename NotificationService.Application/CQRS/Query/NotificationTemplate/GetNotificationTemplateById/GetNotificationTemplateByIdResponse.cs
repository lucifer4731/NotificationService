using NotificationService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Query.NotificationTemplate.GetNotificationTemplateById
{
    public class GetNotificationTemplateByIdResponse
    {
        public NotificationTemplateDto NotificationTemplate{ get; set; }
    }
}
