using Bluesense.Application.DTOs;
using Bluesense.Application.Interfaces;

namespace Bluesense.Application.Services
{
    public class GroupService : IGroupService
    {
        public Task<GroupDto> CreateGroupAsync(string name, string? description, bool isPrivate, Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public Task InviteUserAsync(Guid groupId, Guid inviterId, string inviteeEmail)
        {
            throw new NotImplementedException();
        }

        public Task ApproveMembershipAsync(Guid groupId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupDto>> GetUserGroupsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto?> GetGroupByIdAsync(Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}