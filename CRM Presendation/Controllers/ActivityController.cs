using CRM_Presendation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM_Presendation.Controllers
{
    public class ActivityController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();
        ActivityViewModel _activityViewModel;
        List<ActivityViewModel> _activityViewModels;
        public ActivityController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult Index()
        {
            var _activityViewModels = GetAllActivities();

            return View(_activityViewModels.Result.ToList());
        }

        [HttpGet]
        public async Task<List<ActivityViewModel>> GetAllActivities()
        {
            _activityViewModels = new List<ActivityViewModel>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7099/api/Activity"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _activityViewModels = JsonConvert.DeserializeObject<List<ActivityViewModel>>(apiResponse);
                }
            }
            return _activityViewModels;
        }
    }
}
