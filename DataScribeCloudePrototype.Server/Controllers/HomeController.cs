using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataScribeCloudePrototype.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;

        public HomeController(ApplicationDbContext context, UserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(User user) {
            _userManager.AddUser(user);
            return CreatedAtAction(nameof(GetUsers), new { id = new User().Id }, user);
        } 
    }
}
