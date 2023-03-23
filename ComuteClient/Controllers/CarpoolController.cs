using ComuteClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ComuteClient.Controllers
{
    public class CarpoolController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7292/api");
        HttpClient client = new HttpClient();

        public CarpoolController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public async Task<List<Carpool>> CarPools()
        {
            List<Carpool> list = new List<Carpool>();
            HttpResponseMessage response = client.GetAsync(baseAddress + "/CarPool/GetAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Carpool>>(data);
            }
            return list;
        }

        public async Task<List<OwnerCarpool>> GetJoinedByUserId(int UserId)
        {
            List<OwnerCarpool> list = new List<OwnerCarpool>();
            HttpResponseMessage response = await client.GetAsync(baseAddress + "/OwnerCarpool/GetByUserId/" + UserId);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<OwnerCarpool>>(data);
            }
            return list;
        }

        [HttpPost]
        public IActionResult Create(Carpool carPool)
        {
     
                string data = JsonConvert.SerializeObject(carPool);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = client.PostAsync(client.BaseAddress + "/CarPool/Save", content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return Json(content);
                }
                else return BadRequest();
            
      
        }


    }
}
