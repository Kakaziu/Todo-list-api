using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;

namespace TaskSystem.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult<User> Index()
        {
            return Ok();
        }
    }
}
