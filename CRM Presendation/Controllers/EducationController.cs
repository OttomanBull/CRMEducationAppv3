using CRM_Presendation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM_Presendation.Controllers
{
    public class EducationController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        EducationViewModel _educationViewModel;
        List<EducationViewModel> _educationViewModels;
        public EducationController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult Index()
        {
            var _educationViewModels = GetAllEducations();

            return View(_educationViewModels.Result.ToList());
        }

        [HttpGet]
        public async Task<List<EducationViewModel>> GetAllEducations()
        {
            _educationViewModels = new List<EducationViewModel>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7099/api/Education"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _educationViewModels = JsonConvert.DeserializeObject<List<EducationViewModel>>(apiResponse);
                }
            }
            return _educationViewModels;
        }
    }
}
