using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ILogger<SeatController> _logger;
        private readonly ISeatRepository _seatRepository;

        public SeatController(ISeatRepository seatRepository,ILogger<SeatController> logger)
        {
            _logger = logger;
            _seatRepository = seatRepository;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_seatRepository.GetAll()); 
        }
        
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var seat = _seatRepository.Get(id);
            if (seat != null)
            {
                return Ok(seat);
            }
            return NotFound($"seat with Id: {id} was not found");
        }
        
        [HttpPost()]
        public ActionResult Create([FromBody] Seat newSeat)
        {
            _seatRepository.Add(newSeat);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newSeat.Id,newSeat); 
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var seat = _seatRepository.Get(id);
            if (seat != null)
            {
                _seatRepository.Delete(seat);
                return Ok();
            }
            return NotFound($"the requested seat of Id {id} was not found");
        }
        
        [HttpPut("id")]
        public IActionResult Update(int id,[FromBody] Seat newSeat)
        {
            var seat = _seatRepository.Get(id);
            if (seat != null)
            {
                _seatRepository.Update(id,newSeat);
            }
            return Ok(seat);
        }
    }
}