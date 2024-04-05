using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.CQRS.Command.NotificationTemplate.CreateNotificationTemplate;
using NotificationService.Application.CQRS.Query.NotificationTemplate.GetAllNotificationTemplates;
using NotificationService.Application.CQRS.Query.NotificationTemplate.GetNotificationTemplateById;

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
        public async Task<IActionResult> CreateNotificationTemplate([FromQuery] CreateNotificationTemplateQuery request)
        {
            await _mediator.Send(request);
            return Ok();

        }
    }
}
