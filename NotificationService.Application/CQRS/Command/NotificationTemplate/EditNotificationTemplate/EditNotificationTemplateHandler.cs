using MediatR;
using NotificationService.Application.Interfaces.NotificationTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Command.NotificationTemplate.EditNotificationTemplate
{
    public class EditNotificationTemplateHandler : IRequestHandler<EditNotificationTemplateQuery>
    {
        private readonly INotificationTemplateService _notificationTemplateService;

        public EditNotificationTemplateHandler(INotificationTemplateService notificationTemplateService)
        {
        _notificationTemplateService = notificationTemplateService;
        }
        async Task IRequestHandler<EditNotificationTemplateQuery>.Handle(EditNotificationTemplateQuery request, CancellationToken cancellationToken)
        {
            await _notificationTemplateService.Edit(request.NotificationTemplate);
        }
    }
}
