using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service.Interfaces;
using Microsoft.Identity.Client;

namespace DataScribeCloudePrototype.Server.Service
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _context;

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsEmailRegisted(User user) {
            return _context.Set<User>().Any(a => a.Email == user.Email);
        }

        public async Task AddUser(User user)
        {   
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public string HashPaswword(string password) => 
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashPassword);

        
    }
}
