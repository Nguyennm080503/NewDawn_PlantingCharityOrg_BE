using AutoMapper;
using DTOS.Account;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.User
{
    [ApiController]
    public class ProfileController : BaseApiController
    {
        private readonly IUserInformationService _userInformationService;

        public ProfileController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [Authorize(policy: "Member")]
        [HttpGet("user/profile/{accountID}")]
        public async Task<ActionResult> GetProfile(int accountID) 
        {
            var profile = await _userInformationService.GetProfile(accountID);
            return Ok(profile);
        }

        [Authorize(policy: "Member")]
        [HttpPost("user/profile/update")]
        public async Task<ActionResult> UpdateProfile(ProfileUpade profileUpade)
        {
            try
            {
                await _userInformationService.UpdateProfile(profileUpade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Fail excution!"));
            }
        }
    }
}
