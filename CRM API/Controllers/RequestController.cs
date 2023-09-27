using Core.Entitites;
using CRM_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public RequestController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllRequests()
        {
            var request = _context.Requests.ToList();
            return Ok(request);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneRequest([FromRoute(Name = "id")] int id)
        {
            try
            {
                var request = _context.Requests.SingleOrDefault(x => x.Id == id);
                if (request is null)
                    return NotFound();

                return Ok(request);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneRequest([FromBody] Request request)
        {
            try
            {
                if (request is null)
                    return BadRequest();

                _context.Requests.Add(request);
                _context.SaveChanges();

                return StatusCode(201, request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneRequest([FromRoute(Name = "id")] int id, [FromBody] Request request)
        {
            try
            {
                //istenilen kısmı bul
                var entity = _context.Requests.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound();
                if (id != request.Id)
                    return BadRequest();
                      
                

                entity.PersonId          = request.PersonId            ;
                entity.ActivityId        = request.ActivityId          ;
                entity.DemandStatus      = request.DemandStatus        ;
                entity.NumberOfPeople    = request.NumberOfPeople      ;
                entity.CreateDateTime    = request.CreateDateTime      ;
                entity.UpdateDateTime    = request.UpdateDateTime      ;




                _context.SaveChanges();
                return Ok(request);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneRequest([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context.Requests.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Şu Idye Sahip Kitap Bulunamadı: {id}"
                    });

                _context.Requests.Remove(entity);
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
