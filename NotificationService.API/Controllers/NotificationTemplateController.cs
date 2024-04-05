using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.CQRS.Command.NotificationTemplate.CreateNotificationTemplate;
using NotificationService.Application.CQRS.Command.NotificationTemplate.DeleteNotificationTemplate;
using NotificationService.Application.CQRS.Command.NotificationTemplate.EditNotificationTemplate;
using NotificationService.Application.CQRS.Query.NotificationTemplate.GetAllNotificationTemplates;
using NotificationService.Application.CQRS.Query.NotificationTemplate.GetNotificationTemplateById;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interfaces.NotificationTemplate;

namespace NotificationService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationTemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllNotificationTemplatesQuery request)
        {
            //TODO returns error
            var result = await _mediator.Send(request);

            if(result.NotificationTemplates.Count == 0)
                return NotFound();

            return Ok(result.NotificationTemplates);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById([FromQuery] GetNotificationTemplateByIdQuery request)
        {
            var result = await _mediator.Send(request);

            if (result.NotificationTemplate == null)
                return NotFound("Id is not valid");

            return Ok(result.NotificationTemplate);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationTemplate([FromBody] CreateNotificationTemplateQuery request)
        {
            await _mediator.Send(request);
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotificationTemplate([FromBody] EditNotificationTemplateQuery request)
        {
            await _mediator.Send(request);  
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveNotificationTemplate([FromQuery] DeleteNotificationTemplateQuery request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
