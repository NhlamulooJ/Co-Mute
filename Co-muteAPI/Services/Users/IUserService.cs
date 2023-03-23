using Co_MuteBL.DbFunctions;
using Co_MuteDB.Entities;

namespace Co_muteAPI.Services.Users
{
    public interface IUserService
    {
        Task<User> Save(User user);
        Task<User> Update(User user);
        Task<User> GetById(int Id);
        Task<User> Login(string email, string password);

    }
}
