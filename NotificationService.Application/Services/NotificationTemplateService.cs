using AutoMapper;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interfaces.NotificationTemplate;
using NotificationService.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.Services
{
    public class NotificationTemplateService : INotificationTemplateService
    {
        private readonly INotificationTemplateRepository _notificationTemplateRepository;
        private readonly IMapper _mapper;

        public NotificationTemplateService(INotificationTemplateRepository NotificationTemplateRepository, IMapper mapper)
        {
            _notificationTemplateRepository = NotificationTemplateRepository;
            _mapper = mapper;
        }

        public async Task Add(NotificationTemplateDto model)
        {
            List<int> LimitedToDelivaryTypesValues = new List<int>();
            foreach (var item in model.LimitedToDelivaryTypes)
            {
                int value = Convert.ToInt32(model.LimitedToDelivaryTypes);
                LimitedToDelivaryTypesValues.Add(value);
            }

            var notificationTemplate = NotificationTemplate.CreateNew(model.Name, model.Template, model.InternalTokens, model.ExternalTokens, LimitedToDelivaryTypesValues);
            await _notificationTemplateRepository.Insert(notificationTemplate);
        }

        public async Task Edit(NotificationTemplateDto model)
        {
            List<int> LimitedToDelivaryTypesValues = new List<int>();
            foreach (var item in model.LimitedToDelivaryTypes)
            {
                int value = Convert.ToInt32(model.LimitedToDelivaryTypes);
                LimitedToDelivaryTypesValues.Add(value);
            }
            var notificationTemplate = NotificationTemplate.CreateNew(model.Name, model.Template, model.InternalTokens, model.ExternalTokens, LimitedToDelivaryTypesValues);
            await _notificationTemplateRepository.Update(notificationTemplate);
        }

        public async Task<List<NotificationTemplateDto>> GetAll()
        {
            IEnumerable<NotificationTemplate> notificationTemplates = await _notificationTemplateRepository.GetAll();
            var notificationTemplateDto = _mapper.Map<List<NotificationTemplateDto>>(notificationTemplates);
            return notificationTemplateDto;
        }

        public async Task<NotificationTemplateDto> GetById(Guid id)
        {
            var notificationTemplate = await _notificationTemplateRepository.GetById(new NotificationTemplateId(id));
            var notificationTemplateDto = _mapper.Map<NotificationTemplateDto>(notificationTemplate);
            return notificationTemplateDto;
        }

        public void Remove(Guid id)
        {
            _notificationTemplateRepository.Delete(new NotificationTemplateId(id));
        }
    }
}
