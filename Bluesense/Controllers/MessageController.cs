using Microsoft.AspNetCore.Mvc;
using Bluesense.Application.Interfaces;

namespace Bluesense.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] SendMessageRequest request)
        {
            var message = await _messageService.SendMessageAsync(request.GroupId, request.SenderId, request.Content, request.FileUrl);
            return Ok(message);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditMessageRequest request)
        {
            var message = await _messageService.EditMessageAsync(request.MessageId, request.UserId, request.NewContent);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMessageRequest request)
        {
            await _messageService.DeleteMessageAsync(request.MessageId, request.UserId);
            return NoContent();
        }

        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetMessages(Guid groupId, int page = 1, int pageSize = 20)
        {
            var messages = await _messageService.GetMessagesAsync(groupId, page, pageSize);
            return Ok(messages);
        }

        [HttpGet("search/{groupId}")]
        public async Task<IActionResult> SearchMessages(Guid groupId, string searchText, int page = 1, int pageSize = 20)
        {
            var messages = await _messageService.SearchMessagesAsync(groupId, searchText, page, pageSize);
            return Ok(messages);
        }
    }

    public record SendMessageRequest(Guid GroupId, Guid SenderId, string Content, string? FileUrl);
    public record EditMessageRequest(Guid MessageId, Guid UserId, string NewContent);
    public record DeleteMessageRequest(Guid MessageId, Guid UserId);
}