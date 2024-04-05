using NotificationService.Application.Dtos;
using NotificationService.Domain.Notification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NotificationService.Application.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        private readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
        };

        public MappingProfiles()
        {

            CreateMap<NotificationTemplate, NotificationTemplateDto>().
                ForMember(dest => dest.ExternalTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.ExternalTokens, _settings))).
                 ForMember(dest => dest.InternalTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.InternalTokens, _settings))).
                  ForMember(dest => dest.LimitedToDelivaryTypes, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.LimitedToDelivaryTypes, _settings)))
            .ReverseMap().
                ForMember(dest => dest.ExternalTokens, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ExternalTokens, _settings))).
                 ForMember(dest => dest.InternalTokens, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.InternalTokens, _settings))).
                  ForMember(dest => dest.LimitedToDelivaryTypes, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.LimitedToDelivaryTypes, _settings)));

            CreateMap<NotificationTemplate, NotificationTemplateDtoForEdit>().
               ForMember(dest => dest.ExternalTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.ExternalTokens, _settings))).
                ForMember(dest => dest.InternalTokens, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.InternalTokens, _settings))).
                 ForMember(dest => dest.LimitedToDelivaryTypes, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.LimitedToDelivaryTypes, _settings)))
           .ReverseMap().
               ForMember(dest => dest.ExternalTokens, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ExternalTokens, _settings))).
                ForMember(dest => dest.InternalTokens, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.InternalTokens, _settings))).
                 ForMember(dest => dest.LimitedToDelivaryTypes, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.LimitedToDelivaryTypes, _settings)));
        }
    }
}


/*
 CreateMap<Source, Dest>()
            .ForMember(dest => dest.Schedule, opt =>
            {
                opt.MapFrom(src => new Schedule((ScheduleBaseEnum)src.ScheduleBaseId, src.ScheduleIncrement));
            })
            .ForMember(dest => dest.SubscriptionCriteria, opt =>
            {
                opt.MapFrom(src => (ISubscriptionCriteria)JsonConvert.DeserializeObject(src.SubscriptionCriteriaJson, GetSubscriptionCriteriaType((SubscriptionTypeEnum)src.SubscriptionTypeId)));
            });
  */