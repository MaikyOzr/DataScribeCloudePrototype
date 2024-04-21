using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Repositories;
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
        private readonly JWTProvider _jWTProvider;
        public RegistrationController
            (ApplicationDbContext context, UserManager userManager, JWTProvider provider)
        {
            _context = context;
            _userManager = userManager;
            _jWTProvider = provider;
        }

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {

            if (register.Password != register.ConfPassword)
            {
                return BadRequest(new { message = "Passwords do not match" });
            }

            var hashPassword = _userManager.HashPaswword(register);
            var user = new User
            {
                Email = register.Email,
                Password = hashPassword
            };

            if (_userManager.IsEmailRegisted(user))
            {
                return BadRequest(new { message = "Mail registered!" });
            }

            await _userManager.AddUser(user);
            return Ok(new { message = "Register successful" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await _userManager.FindByEmail(login);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var verifyPassword = _userManager.Verify(login, user);
            //var token = _jWTProvider.GenerateToken(user);

            if (verifyPassword)
            {
                return Ok("Succes");
            }

            return BadRequest("Incorrect password");
        }


    }
}
