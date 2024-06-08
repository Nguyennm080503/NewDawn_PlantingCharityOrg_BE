using DTOS.PlantTracking;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.Admin
{
    [ApiController]
    public class AdminPlantTrackingController : BaseApiController
    {
        private readonly IPlantTrackingService _plantTrackingService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminPlantTrackingController(IPlantTrackingService plantTrackingService, IWebHostEnvironment webHostEnvironment)
        {
            _plantTrackingService = plantTrackingService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(policy: "Admin")]
        [HttpPost("admin/planttracking/create")]
        public async Task<ActionResult> CreatePlantTracking([FromForm] PlantTrackingCreate trackingCreate)
        {
            try
            {
                await _plantTrackingService.CreatePlantTracking(_webHostEnvironment, trackingCreate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(404, "Fail excution!"));
            }
        }

        [Authorize(policy: "Admin")]
        [HttpGet("admin/plantcodes/detail/{plantcode}")]
        public async Task<ActionResult> GetAllPlantTrackingOfPlantCode(string plantcode)
        {
            var plants = await _plantTrackingService.GetAllTrackingDetailOfPlantCode(plantcode);
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
