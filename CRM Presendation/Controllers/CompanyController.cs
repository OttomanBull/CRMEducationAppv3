﻿using CRM_Presendation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM_Presendation.Controllers
{
    public class CompanyController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        CompanyViewModel _companyViewModel;
        List<CompanyViewModel> _companyViewModels;
        public CompanyController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult Index()
        {
            var _companyViewModels = GetAllCompanies();

            return View(_companyViewModels.Result.ToList());
        }

        [HttpGet]
        public async Task<List<CompanyViewModel>> GetAllCompanies()
        {
            _companyViewModels = new List<CompanyViewModel>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7099/api/Company"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _companyViewModels = JsonConvert.DeserializeObject<List<CompanyViewModel>>(apiResponse);
                }
            }
            return _companyViewModels;
        }
    }
}
