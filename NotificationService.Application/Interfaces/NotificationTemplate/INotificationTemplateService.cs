using NotificationService.Application.Dtos;
using NotificationService.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Interfaces.NotificationTemplate
{
    public interface INotificationTemplateService
    {
        Task<List<NotificationTemplateDto>> GetAll();
        Task<NotificationTemplateDto> GetById(Guid id);
        Task<NotificationTemplateDto> GetByName(string notificationTemplateName);
        Task Add(NotificationTemplateDto model);
        Task Edit(NotificationTemplateDtoForEdit model);
        Task Remove(Guid id);

    }
}
