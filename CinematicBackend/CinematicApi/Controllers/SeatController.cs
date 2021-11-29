using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.Business.Managers;
using Cinematic.DataAccess.Entities;
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
        
        [Route("PendingSeats")]
        [HttpGet]
        public ActionResult GetPendingSeats()
        {
            return Ok(_seatManager.GetPendingSeats()); 
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
        
        [Route("Seats")]
        [HttpGet]
        public ActionResult GetSeats(Guid playId,Guid userId)
        {
            var seat = _seatManager.GetSeats(playId,userId);
            if (seat != null)
            {
                return Ok(seat);
            }
            return NotFound();
        }
        
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(List<SeatDTO> seats,Guid id)
        {
            foreach (var seat in seats)
            {
                seat.PlayId = id;
            }
            _seatManager.Add(seats);
            return Ok(); 
        }
        
        [HttpPost("Accept/{id}")]
        public ActionResult Accept(Guid id)
        {
            _seatManager.Accept(id);
            return Ok(); 
        }
        
        [HttpPost("Decline/{id}")]
        public ActionResult Decline(Guid id)
        {
            _seatManager.Decline(id);
            return Ok(); 
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
    }
}