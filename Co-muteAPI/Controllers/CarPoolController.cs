using Co_muteAPI.Services.CarPools;
using Co_muteAPI.Services.Users;
using Co_MuteDB.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Co_muteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPoolController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly ICarPoolService _carPoolService;
        public CarPoolController(IConfiguration configuration, ICarPoolService carPool)
        {
            _configuration = configuration;
            _carPoolService = carPool;
        }

        //Endpoint to save carpool object to the database
        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult> Save(CarPool carPool)
        {
            if (ModelState.IsValid)
            {
                var result = await _carPoolService.Save(carPool);
                return Ok(result);
            }
            else { return BadRequest(); }
            
        }

        //Endpoint to get all CarPools
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            
            var result = await _carPoolService.GetAll();
            return Ok(result);
        }

        //[HttpGet]
        //[Route("GetNew")]
        //public async Task<ActionResult> GetNew(int userId)
        //{

        //    var result = await _carPoolService.GetAll();
        //    return Ok(result);
        //}


        //Endpoint to get CarPool by Id
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            var result = await _carPoolService.GetById(Id);
            return Ok(result);
        }


       


    }
}
