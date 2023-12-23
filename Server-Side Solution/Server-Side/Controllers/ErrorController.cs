using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server_Side.Erorrs;

namespace Server_Side.Controllers
{
    [Route("erorr/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public ActionResult Erorr(int code)
        {
            return NotFound(new ApiResponse(code,"Not Found End Point"));
        }
    }
}
