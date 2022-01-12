using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UIBlazor.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
       
        public AccountController()
        {
        }

        [Authorize]
        [HttpGet("logout")]
        public IActionResult Logout() => SignOut("Cookies", "oidc");
    }
}
