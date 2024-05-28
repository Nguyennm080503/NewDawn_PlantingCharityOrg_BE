using DTOS.Account;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Admin
{
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserInformationService _userInformationService;
        public UsersController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/users")]
        public async Task<ActionResult<IEnumerable<UserInformationView>>> GetAllUserMemmber()
        {
            var users = await _userInformationService.GetListMemberUser();
            return Ok(users);
        }

        [Authorize(policy: "Admin")]
        [HttpPost("admin/users/update_status")]
        public async Task<ActionResult> UpdateStatusMemberAccount(StatusParams statusParams)
        {
            try
            {
                await _userInformationService.UpdateStatusMemberAccount(statusParams);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseStatus(500, ex.Message));
            }
        }
    }
}
