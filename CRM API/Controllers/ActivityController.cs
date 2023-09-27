using Core.Entitites;
using CRM_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public ActivityController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllActivities()
        {
            try
            {
                var activities = _context.Activities.ToList();
                return Ok(activities);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneActivity([FromRoute(Name = "id")] int id)
        {
            try
            {
                var activity = _context.Activities.SingleOrDefault(x => x.Id == id);
                if (activity is null)
                    return NotFound();

                return Ok(activity);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneActivity([FromBody] Core.Entitites.Activity activity)
        {
            try
            {
                if (activity is null)
                    return BadRequest();

                _context.Activities.Add(activity);
                _context.SaveChanges();

                return StatusCode(201, activity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateoneActivity([FromRoute(Name = "id")] int id, [FromBody] Core.Entitites.Activity activity)
        {
            try
            {
                //istenilen kısmı bul
                var entity = _context.Activities.SingleOrDefault(x => x.Id == id);

                if (entity is null)
                    return NotFound();
                if (id != activity.Id)      
                    return BadRequest();        
                               
                entity.EducationId = activity.EducationId;
                entity.InstructorId = activity.InstructorId;
                entity.ActivityType = activity.ActivityType;
                entity.ActivityLocation = activity.ActivityLocation;
                entity.ClassLowerLimit = activity.ClassLowerLimit;
                entity.ClassUpperLimit = activity.ClassUpperLimit;
                entity.ActivityDate = activity.ActivityDate;
                entity.ActivityPrice = activity.ActivityPrice;
                entity.Certificate = activity.Certificate;
                entity.CreateDateTime = activity.CreateDateTime;
                entity.UpdateDateTime = activity.UpdateDateTime;
                 
                _context.SaveChanges();
                return Ok(activity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneActivity([FromRoute(Name ="id")]int id)
        {
            try
            {
                var entity = _context.Activities.SingleOrDefault(x => x.Id == id);
                
                if(entity is null)
                return NotFound(new
                {
                    StatusCode = 404,
                    message = $"Şu Idye Sahip Kitap Bulunamadı: {id}"
                });

                _context.Activities.Remove(entity);
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
