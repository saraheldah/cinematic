using System;
using Cinematic.Business.DTO;
using Cinematic.Business.Managers;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        private readonly ILogger<PlayController> _logger;
        private readonly IPlayManager _playManager;

        public PlayController(IPlayManager playManager,ILogger<PlayController> logger)
        {
            _logger = logger;
            _playManager = playManager;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_playManager.GetAll()); 
        }
        
        [Route("GetPlay")]
        [HttpGet]
        public ActionResult GetById(Guid id)
        {
            var play = _playManager.Get(id);
            if (play != null)
            {
                return Ok(play);
            }
            return NotFound($"play with Id: {id} was not found");
        }
        
        [HttpGet("{id}")]
        public ActionResult GetByTheaterId(Guid id)
        {
            var plays = _playManager.GetPlayByTheaterId(id);
            if (plays != null)
            {
                return Ok(plays);
            }
            return NotFound($"play with Id: {id} was not found");
        }
        
        [HttpPost("{id}")]
        public ActionResult Create(PlayDTO newPlay,Guid id)
        {
            _playManager.Add(newPlay,id);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newPlay.Id,newPlay); 
        }
        
        [HttpDelete("{id}")] 
        public ActionResult Delete(Guid id)
        {
            var play = _playManager.Get(id);
            if (play == null) return NotFound($"the requested play of Id {id} was not found");
            _playManager.Delete(id);
            return Ok();
        }
        
        [Route("Update")] // in angular =>/api/play/update?id=321
        [HttpPost] 
        public IActionResult Update([FromQuery]Guid id,[FromBody] Play newPlay)
        {
            var play = _playManager.Get(id);
            if (play != null)
            {
                _playManager.Update(id,newPlay);
            }
            return Ok(play);
        }
    }
}