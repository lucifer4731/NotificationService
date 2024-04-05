using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Notification
{
    public interface INotificationTemplateRepository
    {
        Task<IEnumerable<NotificationTemplate>> GetAll();
        Task<NotificationTemplate> GetById(NotificationTemplateId id);
        Task<NotificationTemplateId> Insert(NotificationTemplate notificationTemplate);
        Task Update(NotificationTemplate notificationTemplate);
        Task Delete(NotificationTemplateId id);
    }
}
