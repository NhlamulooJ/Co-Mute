using Co_MuteBL.DbFunctions;
using Co_MuteDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_MuteBL.BLogic.OwnerCarPools
{
    public class OwnerCarPoolBL
    {
        public static async Task<OwnerCarPool> Save(OwnerCarPool carPool)
        {
            return await DbAccess<OwnerCarPool>.Save(carPool);
        }
           public static async Task<OwnerCarPool> Update(OwnerCarPool carPool)
        {
            return await DbAccess<OwnerCarPool>.Update(carPool);
        }
        public static async Task<List<OwnerCarPool>> GetAll()
        {
            return DbAccess<OwnerCarPool>.GetAll().Result.ToList();
        }

        public static async Task<List<OwnerCarPool>> GetByUserId(int Id)
        {
            return DbAccess<OwnerCarPool>.GetQueryable()
                .Include(x=> x.carPool)
                
                .Where(e=>e.UserId == Id).ToList();
        }


    }
}
