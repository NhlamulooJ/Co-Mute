using Co_MuteBL.BLogic.CarPools;
using Co_MuteBL.BLogic.Users;
using Co_MuteDB.Entities;

namespace Co_muteAPI.Services.CarPools
{
    public class CarPoolService : ICarPoolService
    {
        public async Task<CarPool> GetById(int Id)
        {
            return await CarPoolBL.GetById(Id);
        }
        public async Task<CarPool> Save(CarPool carPool)
        {
            return await CarPoolBL.Save(carPool);
        }
        public async Task<List<CarPool>> GetAll()
        {
            return await CarPoolBL.GetAll();
        }

    
    }
}
