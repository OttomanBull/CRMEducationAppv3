using CRM_Presendation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRM_Presendation.Controllers
{
    public class LoginController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        LoginModel _loginModel;


        public LoginController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult IndexAsync()
        {

            return View();

        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    // API URL'sini belirtin
                    string apiUrl = "https://localhost:7099/api/Login/Login";

                    // LoginModel'i JSON formatında API'ye gönder
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    // POST isteği gönderin
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Başarılı giriş
                        ViewBag.SuccessMessage = "Giriş başarılı";
                        var _personViewModels = GetAllPeople();

                        return View("~/Views/Person/Index.cshtml", _personViewModels.Result.ToList());

                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Lütfen tekrar deneyin.";
                        return View("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata işleme kodu
                ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
                return View("Error");
            }
        }
        [HttpGet]
        public async Task<List<PersonViewModel>> GetAllPeople()
        {
           var _personViewModels = new List<PersonViewModel>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7099/api/Person"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _personViewModels = JsonConvert.DeserializeObject<List<PersonViewModel>>(apiResponse);
                }
            }
            return _personViewModels;
        }
    }
}
