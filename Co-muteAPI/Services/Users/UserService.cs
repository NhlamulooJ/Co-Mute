using Co_MuteBL.BLogic.Users;
using Co_MuteBL.DbFunctions;
using Co_MuteDB.Entities;

namespace Co_muteAPI.Services.Users
{
    public class UserService : IUserService
    {
        public async Task<User> Save(User user)
        {
            return await UserBL.Save(user);
        }
        public async Task<User> GetById(int userID)
        {
            return await UserBL.GetById(userID);
        }
        public async Task<User> Update(User user)
        {
            return await UserBL.Update(user);
        }
        public async Task<User> Login(string email, string password)
        {
            return await UserBL.Login(email, password);
        }
    }
}
