using Microsoft.AspNetCore.Mvc;

namespace EXE201_NEWDAWN_BE.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BaseApiController : ControllerBase
    {
        protected int GetLoginAccountId()
        {
            try
            {
                return int.Parse(this.User.Claims.First(i => i.Type == "AccountId").Value);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
