using MediatR;
using NotificationService.Application.Interfaces.NotificationTemplate;
using NotificationService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Command.NotificationTemplate.DeleteNotificationTemplate
{
    public class DeleteNotificationTemplateHandler : IRequestHandler<DeleteNotificationTemplateQuery>
    {
        private readonly INotificationTemplateService _notificationTemplateService;

        public DeleteNotificationTemplateHandler(INotificationTemplateService notificationTemplateService)
        {
            _notificationTemplateService = notificationTemplateService;
        }
        public async Task Handle(DeleteNotificationTemplateQuery request, CancellationToken cancellationToken)
        {
            await _notificationTemplateService.Remove(request.NotificationTemplateId);
        }
    }
}
