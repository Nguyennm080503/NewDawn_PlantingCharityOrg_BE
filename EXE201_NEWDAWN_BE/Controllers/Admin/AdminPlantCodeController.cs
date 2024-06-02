using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Admin
{
    [ApiController]
    public class AdminPlantCodeController : BaseApiController
    {
        private readonly IPlantCodeService _plantCodeService;

        public AdminPlantCodeController(IPlantCodeService plantCodeService)
        {
            _plantCodeService = plantCodeService;
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/plantcodes")]
        public async Task<ActionResult> GetAllPlantCodes()
        {
            var plants = await _plantCodeService.GetAllPlantCodes();
            if (plants != null)
            {
                return Ok(plants);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/plantcodes/newest")]
        public async Task<ActionResult> Get6PlantCodes()
        {
            var plants = await _plantCodeService.Get6TheNewestPlantCode();
            if (plants != null)
            {
                return Ok(plants);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }
    }
}
