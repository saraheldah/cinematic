using System.Collections.Generic;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")] //that means that our controller is going to listen to anything that comes with the path api/controller
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ILogger<TheaterController> _logger;
        private readonly ITheaterRepository _theaterRepository;

        public TheaterController(ITheaterRepository theaterRepository,ILogger<TheaterController> logger)
        {
            _logger = logger;
            _theaterRepository = theaterRepository;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_theaterRepository.GetAll()); 
        }
        
        [HttpGet("{id}")] // the path becomes => id/courses/id 
        public ActionResult GetById(int id)
        {
            var theater = _theaterRepository.Get(id);
            if (theater != null)
            {
                return Ok(theater);
            }
            return NotFound($"theater with Id: {id} was not found");
        }
        
        [HttpPost()]
        public ActionResult Create([FromBody] Theater newTheater)
        {
            _theaterRepository.Add(newTheater);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newTheater.Id,newTheater); 
        }
        
        [HttpDelete("{id}")] // the path becomes => id/theater/id 
        public ActionResult Delete(int id)
        {
            var theater = _theaterRepository.Get(id);
            if (theater != null)
            {
                _theaterRepository.Delete(theater);
                return Ok();
            }
            return NotFound($"the requested theater of Id {id} was not found");
        }
        
        [HttpPut("id")] // the path becomes => id/theater/id 
        public IActionResult Update(int id,[FromBody] Theater newTheater)
        {
            var theater = _theaterRepository.Get(id);
            if (theater != null)
            {
                _theaterRepository.Update(id,newTheater);
            }
            return Ok(theater);
        }
    }
}