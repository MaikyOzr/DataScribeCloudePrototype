using DataScribeCloudePrototype.Server.Models;

namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IUserManager
    {
        Task AddUser(User user);
        Task<User> FindByEmail(LoginModel login);
        bool IsEmailRegisted(User user);
        string HashPaswword(RegisterModel password);
        bool Verify(LoginModel password, User hashPassword);
    }
}
