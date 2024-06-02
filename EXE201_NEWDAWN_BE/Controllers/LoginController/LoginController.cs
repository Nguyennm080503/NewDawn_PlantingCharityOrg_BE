using DTOS.Login;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.LoginController
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserInformationService _userInformationService;
        public LoginController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> GetAccountLoginByUsername(LoginDto loginDto)
        {
            var accountLogin = await _userInformationService.GetAccountLoginByUsername(loginDto);
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
