using CRM_Presendation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Security;
using System.Text;

namespace CRM_Presendation.Controllers
{
    public class PersonController : Controller
    {

        HttpClientHandler _clientHandler = new HttpClientHandler();
        PersonViewModel _personViewModel;
        List<PersonViewModel> _personViewModels;

        public PersonController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult IndexAsync()
        {
            var _personViewModels = GetAllPeople();
            
            return View(_personViewModels.Result.ToList());
        }

        [HttpGet]
        public async Task<List<PersonViewModel>> GetAllPeople()
        {
            _personViewModels = new List<PersonViewModel>();
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

        [HttpGet]
        public async Task<PersonViewModel> GetPersonById(int personId)
        {
            _personViewModel = new PersonViewModel();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7099/api/Person/" + personId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _personViewModel = JsonConvert.DeserializeObject<PersonViewModel>(apiResponse);
                }
            }
            return _personViewModel;
        }


        [HttpPost]
        public async Task<PersonViewModel> CreateOnePerson(PersonViewModel person)
        {
            _personViewModel = new PersonViewModel();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7099/api/Person", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _personViewModel = JsonConvert.DeserializeObject<PersonViewModel>(apiResponse);
                }
            }
            return _personViewModel;
        }


        [HttpDelete]
        public async Task<string> DeleteOnePerson(int personId)
        {
            string message = "";
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7099/api/Person/" + personId))
                {
                    message = await response.Content.ReadAsStringAsync();

                }
            }
            return message;
        }
    }
}
