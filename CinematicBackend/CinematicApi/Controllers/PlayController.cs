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
        private readonly IPlayRepository _playRepository;

        public PlayController(IPlayRepository playRepository,ILogger<PlayController> logger)
        {
            _logger = logger;
            _playRepository = playRepository;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_playRepository.GetAll()); 
        }
        
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var play = _playRepository.Get(id);
            if (play != null)
            {
                return Ok(play);
            }
            return NotFound($"play with Id: {id} was not found");
        }
        
        [HttpPost()]
        public ActionResult Create([FromBody] Play newPlay)
        {
            _playRepository.Add(newPlay);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newPlay.Id,newPlay); 
        }
        
        [HttpDelete("{id}")] 
        public ActionResult Delete(int id)
        {
            var play = _playRepository.Get(id);
            if (play != null)
            {
                _playRepository.Delete(play);
                return Ok();
            }
            return NotFound($"the requested play of Id {id} was not found");
        }
        
        [HttpPut("id")] 
        public IActionResult Update(int id,[FromBody] Play newPlay)
        {
            var play = _playRepository.Get(id);
            if (play != null)
            {
                _playRepository.Update(id,newPlay);
            }
            return Ok(play);
        }
    }
}