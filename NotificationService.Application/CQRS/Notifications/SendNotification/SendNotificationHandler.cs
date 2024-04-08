using MediatR;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NotificationService.Application.Interfaces.NotificationTemplate;
using NotificationService.Application.Interfaces.SendNotification;
using NotificationService.Application.RabitMQ;
using NotificationService.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Notifications.SendNotification
{
    public class SendNotificationHandler : INotificationHandler<SendNotificationQuery>
    {
        private readonly ISmtpEmailSender _emailSender;
        private readonly ISMSSender _sMSSender;
        private readonly INotificationTemplateService _notificationTemplateService;
        private readonly StringUtility _stringUtility;
        private readonly IConfiguration _configuration;
        private readonly IMessageReceiver _messageReceiver;

        public SendNotificationHandler(ISmtpEmailSender emailSender, ISMSSender sMSSender, INotificationTemplateService notificationTemplateService, IMessageReceiver messageReceiver, StringUtility stringUtility, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _sMSSender = sMSSender;
            _notificationTemplateService = notificationTemplateService;
            _messageReceiver = messageReceiver;
            _stringUtility = stringUtility;
            _configuration = configuration;
        }

        public async Task Handle(SendNotificationQuery notification, CancellationToken cancellationToken)
        {
            var template = await _notificationTemplateService.GetByName(notification.TemplateName);

            if (_configuration.GetValue<bool>("SendEmail") == true)
            await _emailSender.SendEmailAsync(notification.UserId, template.Template, notification.ExternalTokens);

            if (_configuration.GetValue<bool>("SendSMS") == true)
                 await _sMSSender.SendSmsAsync(notification.UserId,template.Template,notification.ExternalTokens);

        }

    }
}
