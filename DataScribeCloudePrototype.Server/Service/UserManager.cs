using DataScribeCloudePrototype.Server.Data;
using DataScribeCloudePrototype.Server.Models;
using DataScribeCloudePrototype.Server.Service.Interfaces;

namespace DataScribeCloudePrototype.Server.Service
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _context;

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {   
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}
