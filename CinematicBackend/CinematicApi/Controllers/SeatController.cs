using System;
using Cinematic.Business.DTO;
using Cinematic.Business.Managers;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using MongoDB.Driver;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ILogger<SeatController> _logger;
        private readonly ISeatManager _seatManager;

        public SeatController(ISeatManager seatManager,ILogger<SeatController> logger)
        {
            _logger = logger;
            _seatManager = seatManager;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_seatManager.GetAll()); 
        }
        
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var seat = _seatManager.Get(id);
            if (seat != null)
            {
                return Ok(seat);
            }
            return NotFound($"seat with Id: {id} was not found");
        }
        
        // [HttpGet("Reserved")]
        // public ActionResult GetSeats(Guid playId)
        // {
        //     var seat = _seatManager.Find(playId);
        //     if (seat != null)
        //     {
        //         return Ok(seat);
        //     }
        //     return NotFound($"seat with Id: {playId} was not found");
        // }
        
        [HttpPost()]
        public ActionResult Create([FromBody] Seat newSeat)
        {
            _seatManager.Add(newSeat);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newSeat.Id,newSeat); 
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var seat = _seatManager.Get(id);
            if (seat != null)
            {
                _seatManager.Delete(id);
                return Ok();
            }
            return NotFound($"the requested seat of Id {id} was not found");
        }
        
        [HttpPut("id")]
        public IActionResult Update(Guid id,[FromBody] Seat newSeat)
        {
            var seat = _seatManager.Get(id);
            if (seat != null)
            {
                _seatManager.Update(id,newSeat);
            }
            return Ok(seat);
        }
    }
}