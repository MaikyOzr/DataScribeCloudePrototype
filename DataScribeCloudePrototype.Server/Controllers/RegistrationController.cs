using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(CacheProfileName = "Default30")]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;
        
        public RegistrationController(ApplicationDbContext context, UserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    
        [HttpPost("Register")]
        public async Task<IActionResult> Register(string email, string password) {

            var hashPassword = _userManager.HashPaswword(password);
            var user = new User
            {
                Email = email,
                Password = hashPassword
            };
            if (_userManager.IsEmailRegisted(user))
            {
                return BadRequest("Mail registered!");
            }
            await _userManager.AddUser(user);

            return Ok("User is successfully registered!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string? email, string? password)
        {
            var user = await _userManager.FindByEmail(email);
            var verifyPassword = _userManager.Verify(password, user.Password);
            if (verifyPassword) {
                return Ok("You are successfully logged in");
            }
            
            return Ok("Your email or password is not correct");
        }


    }
}
