using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataScribeCloudePrototype.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                return BadRequest("Електронна пошта вже зареєстрована!");
            }
            await _userManager.AddUser(user);

            return Ok("Користувач успішно зареєстрований!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string? email, string? password)
        {
            var user = await _userManager.FindByEmail(email);
            var verifyPassword = _userManager.Verify(password, user.Password);
            if (verifyPassword) {
                return Ok("Ви успішно залогінені");
            }
            
            return Ok("Ваша пошта або пароль не правельні");
        }


    }
}
