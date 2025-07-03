using Bluesense.Application.DTOs;
using Bluesense.Application.Interfaces;

namespace Bluesense.Application.Services
{
    public class MessageService : IMessageService
    {
        public Task<MessageDto> SendMessageAsync(Guid groupId, Guid senderId, string content, string? fileUrl = null)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto?> EditMessageAsync(Guid messageId, Guid userId, string newContent)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMessageAsync(Guid messageId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MessageDto>> GetMessagesAsync(Guid groupId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MessageDto>> SearchMessagesAsync(Guid groupId, string searchText, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}