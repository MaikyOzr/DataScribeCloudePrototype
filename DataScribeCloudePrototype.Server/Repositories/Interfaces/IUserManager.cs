using DataScribeCloudePrototype.Server.Models;

namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IUserManager
    {
        Task AddUser(User user);
        Task <User> FindByEmail(string? email);
        bool IsEmailRegisted(User user);
        string HashPaswword(string password);
        bool Verify(string password, string hashPassword);
    }
}
