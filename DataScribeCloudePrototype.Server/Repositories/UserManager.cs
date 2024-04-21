using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DataScribeCloudePrototype.Server.Service
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsEmailRegisted(User user)
        {
            return _context.Set<User>().Any(a => a.Email == user.Email);
        }

        public async Task AddUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Guid GetCurrUserId()
        {
            var userIdString = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdString, out Guid userId))
            {
                return userId;
            }
            return Guid.Empty;
        }

        public string HashPaswword(RegisterModel password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password.Password);

        public bool Verify(LoginModel password, User hashPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password?.Password, hashPassword.Password);

        public async Task<User> FindByEmail(LoginModel login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            var user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(e => e.Email == login.Email);

            return user;
        }
    }
}
