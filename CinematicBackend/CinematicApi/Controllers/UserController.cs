using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository,ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_userRepository.GetAll()); 
        }
        
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"user with Id: {id} was not found");
        }
        
        [HttpPost()]
        public ActionResult Create([FromBody] User newUser)
        {
            _userRepository.Add(newUser);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + newUser.Id,newUser); 
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                return Ok();
            }
            return NotFound($"the requested user of Id {id} was not found");
        }
        
        [HttpPut("id")] 
        public IActionResult Update(int id,[FromBody] User newUser)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                _userRepository.Update(id,newUser);
            }
            return Ok(user);
        }
    }
}