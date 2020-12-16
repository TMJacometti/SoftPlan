using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SoftPlan.API.Controllers
{
    [ApiController]
    //[Authorize("Bearer")]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public int LoggedUserId = 0;
        public string LoggedUserName = "";
        public string LoggedUserEmail = "";

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("showmethecode")]
        [HttpGet]
        public string getshowmethecode()
        {
            return HttpContext.Request.Path.Value;
        }

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext.User.FindFirst("Id") != null)
            {
                LoggedUserId = int.Parse(httpContextAccessor.HttpContext.User.FindFirst("Id").Value);
                LoggedUserName = httpContextAccessor.HttpContext.User.FindFirst("Name").Value;
                LoggedUserEmail = httpContextAccessor.HttpContext.User.FindFirst("Email").Value;
            }
        }
    }
}