using Core.Entitites;
using CRM_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public EducationController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEducations()
        {
            try
            {
                var educations = _context.Educations.ToList();
                return Ok(educations);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneEducation([FromRoute(Name = "id")] int id)
        {
            try
            {
                var education = _context.Educations.SingleOrDefault(x => x.Id == id);
                if (education is null)
                    return NotFound();

                return Ok(education);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneEducation([FromBody] Education education)
        {
            try
            {
                if (education is null)
                    return BadRequest();

                _context.Educations.Add(education);
                _context.SaveChanges();

                return StatusCode(201, education);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneEducation([FromRoute(Name = "id")] int id, [FromBody] Education education)
        {
            try
            {
                //istenilen kısmı bul
                var entity = _context.Educations.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound();
                if (id != education.Id)
                    return BadRequest();

                entity.EducationName = education.EducationName;
                entity.EducationContents = education.EducationContents;
                entity.Comment = education.Comment;
                entity.IsActive = education.IsActive;
                entity.CreateDateTime = education.CreateDateTime;
                entity.UpdateDateTime = education.UpdateDateTime;
                
               

                _context.SaveChanges();
                return Ok(education);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneEducation([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _context.Educations.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Şu Idye Sahip Kitap Bulunamadı: {id}"
                    });

                _context.Educations.Remove(entity);
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
