using Co_muteAPI.Services.CarPools;
using Co_muteAPI.Services.OwnerCarPools;
using Co_MuteDB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Co_muteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerCarPoolController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly IOwnerCarPoolService _ownerCarPoolService;
        public OwnerCarPoolController(IConfiguration configuration, IOwnerCarPoolService carPool)
        {
            _configuration = configuration;
            _ownerCarPoolService = carPool;
        }

        //Endpoint to get OwnerCarpool by Id
        [HttpGet]
        [Route("GetByUserId")]
        public async Task<ActionResult> GetByUserId(int userId)
        {
                var result = await _ownerCarPoolService.GetByUserId(userId);
                return Ok(result);
        }

        //Endpoint to Join a carpool
        [HttpPost]
        [Route("Join")]
        public async Task<ActionResult> Join(OwnerCarPool carPool)
        {
            if (ModelState.IsValid)
            {
                carPool.Status = "Joined";
                var result = await _ownerCarPoolService.Save(carPool);
                return Ok(result);
            }
            else {
                return BadRequest();
            }
           
        }
        //Endpoint to leave a carpool
        [HttpPost]
        [Route("Leave")]
        public async Task<ActionResult> Leave(OwnerCarPool carPool)
        {
            if (ModelState.IsValid)
            {
                carPool.Status = "Left";
                var result = await _ownerCarPoolService.Update(carPool);
                return Ok(result);
            }
            else return BadRequest();
           
        }

        //Endpoint to Get all ownerCarpools
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _ownerCarPoolService.GetAll();
            return Ok(result);
        }



    }
}
