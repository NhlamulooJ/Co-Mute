using Co_MuteBL.DbFunctions;
using Co_MuteDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_MuteBL.BLogic.CarPools
{
    public class CarPoolBL
    {
        public static async Task<CarPool> Save(CarPool carPool)
        {
            return await DbAccess<CarPool>.Save(carPool);
        }
        public static async Task<List<CarPool>> GetAll()
        {
            return DbAccess<CarPool>.GetAll().Result.ToList();
        }
        //public static async Task<List<CarPool>> GetNew(int userId)
        //{
        //    var x = from q in DbAccess<CarPool>.GetQueryable().Include(s => s.ownerCarPools)
        //            select q; 

            


        //    return DbAccess<CarPool>.GetQueryable()
        //        .Include(e => e.ownerCarPools)
              
                
        //}

        public static async Task<CarPool> GetById(int Id)
        {
            return DbAccess<CarPool>.GetQueryable().Where(br => br.Id == Id).FirstOrDefault();
        }
    }
}
