using Bluesense.Application.DTOs;

namespace Bluesense.Application.Interfaces
{
    public interface IGroupService
    {
        Task<GroupDto> CreateGroupAsync(string name, string? description, bool isPrivate, Guid ownerId);
        Task InviteUserAsync(Guid groupId, Guid inviterId, string inviteeEmail);
        Task ApproveMembershipAsync(Guid groupId, Guid userId);
        Task<IEnumerable<GroupDto>> GetUserGroupsAsync(Guid userId);
        Task<GroupDto?> GetGroupByIdAsync(Guid groupId);
    }
}