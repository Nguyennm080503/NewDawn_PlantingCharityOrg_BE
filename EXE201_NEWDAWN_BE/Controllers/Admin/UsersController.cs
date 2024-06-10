using DTOS.Account;
using DTOS.Login;
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
            try
            {
                var users = await _userInformationService.GetListMemberUser();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseStatus(500, ex.Message));
            }
        }

        [Authorize(policy: "Admin")]
        [HttpPut("admin/users/update_status")]
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

        [Authorize(policy: "Admin")]
        [HttpPost("admin/users/create-account")]
        public async Task<ActionResult> CreateAccount(AccountCreate account)
        {
            try
            {
                await _userInformationService.CreateAccount(account);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseStatus(500, ex.Message));
            }
        }

        [HttpPost("admin/login-permission")]
        public async Task<ActionResult> LoginAdminPermission(LoginDto account)
        {
            var accountLogin = await _userInformationService.GetAccountLoginByAdminPermission(account);
            if (accountLogin != null)
            {
                return Ok(accountLogin);
            }
            else
            {
                return Unauthorized(new ApiResponseStatus(401));
            }
        }
    }
}
