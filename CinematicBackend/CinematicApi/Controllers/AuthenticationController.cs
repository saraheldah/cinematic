using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace CinematicBackend.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        
        public AuthenticationController(IUserRepository userRepo, IMapper mapper, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        [HttpPost]
        public IActionResult Register(UserDTO userDto)
        {
            userDto.Username = userDto.Username.ToLower();

            if ( _userRepo.UserExists(userDto.Username))
                return BadRequest("username taken!");

            var userToCreate = _mapper.Map<User>(userDto);
            _userRepo.Register(userToCreate, userDto.Password);
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(UserDTO userDto)
        {
            var userFromRepo =  _userRepo.Login(userDto.Username.ToLower(), userDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<UserDTO>(userFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}