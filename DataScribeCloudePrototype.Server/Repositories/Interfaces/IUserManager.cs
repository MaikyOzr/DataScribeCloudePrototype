using DataScribeCloudePrototype.Server.Models;

namespace DataScribeCloudePrototype.Server.Service.Interfaces
{
    public interface IUserManager
    {
        Task AddUser(User user);
        Task <User> FindByEmail(string? email);
    }
}
