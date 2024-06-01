using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Admin
{
    [ApiController]
    public class TotalStatisticController : BaseApiController
    {
        private readonly IDashboardService _dashboardService;

        public TotalStatisticController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/total")]
        public async Task<ActionResult> GetTotal()
        {
            var total = await _dashboardService.GetStatisticAsync();
            if(total != null) 
            {
                return Ok(total);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }
    }
}
