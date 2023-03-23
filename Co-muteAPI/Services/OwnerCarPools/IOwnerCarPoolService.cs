using Co_MuteDB.Entities;

namespace Co_muteAPI.Services.OwnerCarPools
{
    public interface IOwnerCarPoolService
    {
        Task<OwnerCarPool> Save(OwnerCarPool carPool);

        Task<OwnerCarPool> Update(OwnerCarPool carPool);

        Task<List<OwnerCarPool>> GetAll();

        Task<List<OwnerCarPool>> GetByUserId(int userId);
    }
}
