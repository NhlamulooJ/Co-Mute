using Co_MuteBL.BLogic.CarPools;
using Co_MuteBL.BLogic.OwnerCarPools;
using Co_MuteDB.Entities;

namespace Co_muteAPI.Services.OwnerCarPools
{
    public class OwnerCarPoolService : IOwnerCarPoolService
    {
      
        public async Task<OwnerCarPool> Save(OwnerCarPool carPool)
        {
            return await OwnerCarPoolBL.Save(carPool);
        }
        public async Task<OwnerCarPool> Update(OwnerCarPool carPool)
        {
            return await OwnerCarPoolBL.Update(carPool);
        }
        public async Task<List<OwnerCarPool>> GetAll()
        {
            return await OwnerCarPoolBL.GetAll();
        }

        public async Task<List<OwnerCarPool>> GetByUserId(int userId)
        {
            return await OwnerCarPoolBL.GetByUserId(userId);
        }
    }
}
