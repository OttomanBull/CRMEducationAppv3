using Core.Entitites;
using CRM_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public  CompanyController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            try
            {
                var companies = _context.Companies.ToList();
                return Ok(companies);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneCompany([FromRoute(Name = "id")] int id)
        {
            try
            {
                var company = _context.Companies.SingleOrDefault(x => x.Id == id);
                if (company is null)
                    return NotFound();

                return Ok(company);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneCompany([FromBody] Company company)
        {
            try
            {
                if (company is null)
                    return BadRequest();

                _context.Companies.Add(company);
                _context.SaveChanges();

                return StatusCode(201, company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateoneCompany([FromRoute(Name = "id")] int id, [FromBody] Company company)
        {
            try
            {
                //istenilen kısmı bul
                var entity = _context.Companies.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound();
                if (id != company.Id)
                    return BadRequest();

                entity.CompanyName = company.CompanyName;
                entity.CompanyLocation = company.CompanyLocation;
                entity.CompanyPhone = company.CompanyPhone;
                entity.WebSite = company.WebSite;
                entity.IsActive = company.IsActive;
                entity.CreateDateTime = company.CreateDateTime;
                entity.UpdateDateTime = company.UpdateDateTime;
            
                _context.SaveChanges();
                return Ok(company);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCompany([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context.Companies.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Şu Idye Sahip Kitap Bulunamadı: {id}"
                    });

                _context.Companies.Remove(entity);
                _context.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
