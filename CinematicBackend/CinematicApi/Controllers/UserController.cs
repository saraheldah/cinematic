using System;
using Cinematic.Business.Managers;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager,ILogger<UserController> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_userManager.GetAll()); 
        }
        
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var user = _userManager.Get(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"user with Id: {id} was not found");
        }
        
        [HttpPost()]
        public ActionResult Create([FromBody] User newUser)
        {
            _userManager.Add(newUser);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newUser.Id,newUser); 
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var user = _userManager.Get(id);
            if (user == null) return NotFound($"the requested user of Id {id} was not found");
            _userManager.DeleteUser(id);
            return Ok();
        }
        
        [Route("Update")]
        [HttpPost()] 
        public IActionResult Update([FromQuery]Guid id,[FromBody] User newUser)
        {
            var user = _userManager.Get(id);
            if (user != null)
            {
                _userManager.Update(id,newUser);
            }
            return Ok(user);
        }
    }
}