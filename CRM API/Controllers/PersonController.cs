using Core.Entitites;
using CRM_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public PersonController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var people = _context.People.ToList();
            return Ok(people);
        }

        [HttpPost]
        public IActionResult CreateOneActivity([FromBody] Person person)
        {
            try
            {
                if (person is null)
                    return BadRequest();

                _context.People.Add(person);
                _context.SaveChanges();

                return StatusCode(201, person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
