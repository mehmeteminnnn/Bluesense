using Bluesense.Application.DTOs;

namespace Bluesense.Application.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDto> SendMessageAsync(Guid groupId, Guid senderId, string content, string? fileUrl = null);
        Task<MessageDto?> EditMessageAsync(Guid messageId, Guid userId, string newContent);
        Task DeleteMessageAsync(Guid messageId, Guid userId);
        Task<IEnumerable<MessageDto>> GetMessagesAsync(Guid groupId, int page, int pageSize);
        Task<IEnumerable<MessageDto>> SearchMessagesAsync(Guid groupId, string searchText, int page, int pageSize);
    }
}