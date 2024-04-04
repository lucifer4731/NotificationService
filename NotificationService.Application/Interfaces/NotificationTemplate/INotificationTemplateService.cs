using NotificationService.Application.Dtos;
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
        Task Add(NotificationTemplateDto model);
        Task Edit(NotificationTemplateDto model);
        void Remove(Guid id);

    }
}
