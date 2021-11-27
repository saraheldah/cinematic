using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.Business.Managers;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly ILogger<TheaterController> _logger;
        private readonly ITheaterManager _theaterManager;

        public TheaterController(ITheaterManager theaterManager,ILogger<TheaterController> logger)
        {
            _logger = logger;
            _theaterManager = theaterManager;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_theaterManager.GetAll()); 
        }
        
        [HttpGet("{id}")] 
        public ActionResult GetById(Guid id)
        {
            var theater = _theaterManager.Get(id);
            if (theater != null)
            {
                return Ok(theater);
            }
            return NotFound($"theater with Id: {id} was not found");
        }
        
        [HttpPost()]
        public ActionResult Create([FromBody]TheaterDTO newTheater)
        {
            _theaterManager.Add(newTheater);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newTheater.Id,newTheater); 
        }
        
        [HttpDelete("{id}")] 
        public ActionResult Delete(Guid id)
        {
            var theater = _theaterManager.Get(id);
            if (theater == null) return NotFound($"the requested theater of Id {id} was not found");
            _theaterManager.DeleteTheater(id);
            return Ok();
        }
        
        [Route("Update")]
        [HttpPost] 
        public IActionResult Update([FromQuery]Guid id, [FromBody]TheaterDTO newTheater)
        {
            var theater = _theaterManager.Get(id);
            if (theater != null)
            {
                _theaterManager.Update(id,newTheater);
            }
            return Ok(theater);
        }
    }
}