using CRM_Presendation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM_Presendation.Controllers
{
    public class RequestController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        RequestViewModel _requestViewModel;
        List<RequestViewModel> _requestViewModels;
        public RequestController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult Index()
        {
            var _requestViewModels = GetAllRequests();

            return View(_requestViewModels.Result.ToList());
        }

        [HttpGet]
        public async Task<List<RequestViewModel>> GetAllRequests()
        {
            _requestViewModels = new List<RequestViewModel>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7099/api/Request"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _requestViewModels = JsonConvert.DeserializeObject<List<RequestViewModel>>(apiResponse);
                }
            }
            return _requestViewModels;
        }
    }
}
