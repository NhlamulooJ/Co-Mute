using Co_MuteBL.DbFunctions;
using Co_MuteDB.Entities;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_MuteBL.BLogic.Users
{
    public class UserBL
    {
        public static async Task<User> Save(User user)
        {
            return await DbAccess<User>.Save(user);
        }
        public static async Task<User> Update(User user)
        {
            return await DbAccess<User>.Update(user);
        }
        public static async Task<User> Login(string email, string password)
        {
            return DbAccess<User>.GetQueryable().Where(br => br.Email == email && br.Password == password).FirstOrDefault();
        }

        public static async Task<User> GetById(int Id)
        {
            return DbAccess<User>.GetQueryable().Where(br => br.Id == Id).FirstOrDefault();
        }
    }
}
