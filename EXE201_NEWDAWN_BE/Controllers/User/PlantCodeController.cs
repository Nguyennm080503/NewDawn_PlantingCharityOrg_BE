using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.User
{
    [ApiController]
    public class PlantCodeController : BaseApiController
    {
        private readonly IPlantCodeService _plantCodeService;
        private readonly IPlantTrackingService _plantTrackingService;

        public PlantCodeController(IPlantCodeService plantCodeService, IPlantTrackingService plantTrackingService)
        {
            _plantCodeService = plantCodeService;
            _plantTrackingService = plantTrackingService;
        }

        [HttpGet("user/plantcodes/{accountID}")]
        public async Task<ActionResult> GetAllPlantCodeOfUser(int accountID)
        {
            var plants = await _plantCodeService.GetAllPlantCodeOfUser(accountID);
            if(plants != null)
            {
                return Ok(plants);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }

        [HttpGet("user/plantcodes/detail/{plantcode}")]
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
