using AutoMapper;
using MediatR;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interfaces.NotificationTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Query.NotificationTemplate.GetAllNotificationTemplates
{
    public class GetAllNotificationTemplatesHandler : IRequestHandler<GetAllNotificationTemplatesQuery, GetAllNotificationTemplatesResponse>
    {
        private readonly IMapper _mapper;
        private readonly INotificationTemplateService _notificationTemplateService;

        public GetAllNotificationTemplatesHandler(IMapper mapper, INotificationTemplateService notificationTemplateService)
        {
            _mapper = mapper;
            _notificationTemplateService = notificationTemplateService;
        }
        public async Task<GetAllNotificationTemplatesResponse> Handle(GetAllNotificationTemplatesQuery request, CancellationToken cancellationToken)
        {
            var notificationTemplates = await _notificationTemplateService.GetAll();

            var notificationTemplatesDto = _mapper.Map<List<NotificationTemplateDto>>(notificationTemplates);
            GetAllNotificationTemplatesResponse response = new GetAllNotificationTemplatesResponse();
            response.NotificationTemplates = notificationTemplatesDto;
            return response;
        }
    }
}
