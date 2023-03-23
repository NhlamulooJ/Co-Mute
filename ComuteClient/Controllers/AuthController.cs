using ComuteClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ComuteClient.Controllers
{
    public class AuthController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7292/api");
        HttpClient client = new HttpClient();

        public AuthController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(client.BaseAddress + "/Users/Save", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(content);
            }
            else return BadRequest();
        }

        public async Task<IActionResult> Login(LoginViewModel loginData)
        {
                string data = JsonConvert.SerializeObject(loginData);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(client.BaseAddress + "/Users/Login?" + "email=" + loginData.Email + "&" + "password=" + loginData.Password, content);
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                if (responseData != null)
                {
                    User loginResponse = JsonConvert.DeserializeObject<User>(responseData);
                    return Json(loginResponse);
                   
                }
                else return BadRequest();
        }

    }
}
