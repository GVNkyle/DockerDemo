using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected string userName => (HttpContext.User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.Name).Value;

    }
}