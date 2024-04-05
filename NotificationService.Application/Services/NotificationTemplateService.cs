using AutoMapper;
using NotificationService.Application.Dtos;
using NotificationService.Application.Enums;
using NotificationService.Application.Interfaces.NotificationTemplate;
using NotificationService.Application.Utilities;
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
        private readonly JSonUtility _jSonUtility;

        public NotificationTemplateService(INotificationTemplateRepository NotificationTemplateRepository, IMapper mapper, JSonUtility jSonUtility)
        {
            _notificationTemplateRepository = NotificationTemplateRepository;
            _mapper = mapper;
            _jSonUtility = jSonUtility;
        }

        public async Task Add(NotificationTemplateDto model)
        {
            List<int> limitedToDelivaryTypesValuesList = new List<int>();
            for (int i = 0; i < model.LimitedToDelivaryTypes.ToList().Count; i++)
            {
                int value = (int)(DelivaryType)Enum.Parse(typeof(DelivaryType), Convert.ToString(model.LimitedToDelivaryTypes[i]));
                limitedToDelivaryTypesValuesList.Add(value);
            }

            string limitedToDelivaryTypesValues = _jSonUtility.ConvertListToJson(limitedToDelivaryTypesValuesList);
            NotificationTemplate notificationTemplate = _mapper.Map<NotificationTemplate>(model);

            var newNotificationTemplate = NotificationTemplate.CreateNew(notificationTemplate.NotificationTemplateName, model.Template, notificationTemplate.InternalTokens, notificationTemplate.ExternalTokens, limitedToDelivaryTypesValues);
            await _notificationTemplateRepository.Insert(newNotificationTemplate);
        }

        public async Task Edit(NotificationTemplateDtoForEdit model)
        {
            List<int> limitedToDelivaryTypesValuesList = new List<int>();
            for (int i = 0; i < model.LimitedToDelivaryTypes.ToList().Count; i++)
            {
                int value = (int)(DelivaryType)Enum.Parse(typeof(DelivaryType), Convert.ToString(model.LimitedToDelivaryTypes[i]));
                limitedToDelivaryTypesValuesList.Add(value);
            }

            string limitedToDelivaryTypesValues = _jSonUtility.ConvertListToJson(limitedToDelivaryTypesValuesList);
            NotificationTemplate notificationTemplate = _mapper.Map<NotificationTemplate>(model);

            //var newNotificationTemplate = NotificationTemplate.CreateNew(notificationTemplate.NotificationTemplateName, model.Template, notificationTemplate.InternalTokens, notificationTemplate.ExternalTokens, limitedToDelivaryTypesValues);
            await _notificationTemplateRepository.Update(notificationTemplate);
        }

        public async Task<List<NotificationTemplateDto>> GetAll()
        {
            IEnumerable<NotificationTemplate> notificationTemplates = await _notificationTemplateRepository.GetAll();
            List<NotificationTemplateDto> notificationTemplateDto = new List<NotificationTemplateDto>();
            _mapper.Map<NotificationTemplate>(notificationTemplates);
            return notificationTemplateDto;
        }

        public async Task<NotificationTemplateDto> GetById(Guid id)
        {
            var notificationTemplate = await _notificationTemplateRepository.GetById(new NotificationTemplateId(id));
            var notificationTemplateDto = _mapper.Map<NotificationTemplateDto>(notificationTemplate);
            return notificationTemplateDto;
        }

        public async Task Remove(Guid id)
        {
           await _notificationTemplateRepository.Delete(new NotificationTemplateId(id));
        }
    }
}
