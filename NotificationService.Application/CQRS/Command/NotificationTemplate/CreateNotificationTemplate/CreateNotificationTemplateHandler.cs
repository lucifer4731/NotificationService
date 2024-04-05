using MediatR;
using NotificationService.Application.Interfaces.NotificationTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Command.NotificationTemplate.CreateNotificationTemplate
{
    public class CreateNotificationTemplateHandler : IRequestHandler<CreateNotificationTemplateQuery>
    {
        private readonly INotificationTemplateService _notificationTemplateService;

        public CreateNotificationTemplateHandler(INotificationTemplateService notificationTemplateService)
        {
            _notificationTemplateService = notificationTemplateService;
        }
        public async Task Handle(CreateNotificationTemplateQuery request, CancellationToken cancellationToken)
        {
            await _notificationTemplateService.Add(request.NewNotificationTemplate);
        }
    }
}
