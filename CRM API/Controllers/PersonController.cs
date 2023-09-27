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
        [HttpGet("{id:int}")]
        public IActionResult GetOnePerson([FromRoute(Name = "id")] int id)
        {
            try
            {
                var person = _context.People.SingleOrDefault(x => x.Id == id);
                if (person is null)
                    return NotFound();

                return Ok(person);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOnePerson([FromBody] Person person)
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
        [HttpPut("{id:int}")]
        public IActionResult UpdateOnePerson([FromRoute(Name = "id")] int id, [FromBody] Person person)
        {
            try
            {
                //istenilen kısmı bul
                var entity = _context.People.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound();
                if (id != person.Id)
                    return BadRequest();

                entity.Name           = person.Name;
                entity.Surname        = person.Surname;
                entity.Status         = person.Status;
                entity.Phone          = person.Phone;
                entity.CompanyId      = person.CompanyId;
                entity.IsActive       = person.IsActive;
                entity.CreateDateTime = person.CreateDateTime;
                entity.UpdateDateTime = person.UpdateDateTime;
                entity.Comment        = person.Comment;

                _context.SaveChanges();
                return Ok(person);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOnePerson([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context.People.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Şu Idye Sahip Kitap Bulunamadı: {id}"
                    });

                _context.People.Remove(entity);
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
