using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interfaces.NotificationTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.CQRS.Query.NotificationTemplate.GetNotificationTemplateById
{
    public class GetNotificationTemplateByIdHandler : IRequestHandler<GetNotificationTemplateByIdQuery, GetNotificationTemplateByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly INotificationTemplateService _notificationTemplateService;

        public GetNotificationTemplateByIdHandler(IMapper mapper, INotificationTemplateService notificationTemplateService)
        {
            _mapper = mapper;
            _notificationTemplateService = notificationTemplateService;
        }
        public async Task<GetNotificationTemplateByIdResponse> Handle(GetNotificationTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            var notificationTemplate = await _notificationTemplateService.GetById(request.NotificationTemplateId);
            var notificationTemplateDto = _mapper.Map<NotificationTemplateDto>(notificationTemplate);
            GetNotificationTemplateByIdResponse response = new GetNotificationTemplateByIdResponse();
            response.NotificationTemplate = notificationTemplateDto;
            return response;
        }
    }
}
