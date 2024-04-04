using NotificationService.Application.Dtos;
using NotificationService.Domain.Notification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Application.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<NotificationTemplate, NotificationTemplateDto>().
        }
    }
}
