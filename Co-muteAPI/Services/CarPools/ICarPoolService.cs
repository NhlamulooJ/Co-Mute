using Co_MuteDB.Entities;

namespace Co_muteAPI.Services.CarPools
{
    public interface ICarPoolService
    {
        Task<CarPool> Save(CarPool carPool);
        Task<CarPool> GetById(int Id);
       
        Task<List<CarPool>> GetAll();
    }
}
