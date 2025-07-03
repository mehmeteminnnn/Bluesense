using Microsoft.AspNetCore.Mvc;
using Bluesense.Application.Interfaces;

namespace Bluesense.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupRequest request)
        {
            var group = await _groupService.CreateGroupAsync(request.Name, request.Description, request.IsPrivate, request.OwnerId);
            return Ok(group);
        }

        [HttpPost("invite")]
        public async Task<IActionResult> Invite([FromBody] InviteRequest request)
        {
            await _groupService.InviteUserAsync(request.GroupId, request.InviterId, request.InviteeEmail);
            return NoContent();
        }

        [HttpPost("approve")]
        public async Task<IActionResult> Approve([FromBody] ApproveRequest request)
        {
            await _groupService.ApproveMembershipAsync(request.GroupId, request.UserId);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserGroups(Guid userId)
        {
            var groups = await _groupService.GetUserGroupsAsync(userId);
            return Ok(groups);
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroup(Guid groupId)
        {
            var group = await _groupService.GetGroupByIdAsync(groupId);
            if (group == null) return NotFound();
            return Ok(group);
        }
    }

    public record CreateGroupRequest(string Name, string? Description, bool IsPrivate, Guid OwnerId);
    public record InviteRequest(Guid GroupId, Guid InviterId, string InviteeEmail);
    public record ApproveRequest(Guid GroupId, Guid UserId);
}