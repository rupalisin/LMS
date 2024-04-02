using DataAccessLayer.UserRepository;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using DataObjectLayer;

namespace Library_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }
        [HttpPost("Authenticate")]
        public ActionResult Authenticate([FromBody] LoginUser loginObj)
        {
            if (loginObj.Email == null || loginObj.Password == null)
            {
                return BadRequest();
            }
            var users = _user.GetUsers();
            var user = users.FirstOrDefault(x => x.Email == loginObj.Email && x.Password == loginObj.Password);
            if (user == null)
            {
                return NotFound(new { Message = "User Not Found !" });
            }

            user.Token = CreateJwtToken(user);
            return Ok(user);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetUser([FromRoute] int id)
        {
            User user1 = _user.GetUserById(id).Result;
            if (user1 == null)
            {
                return NotFound();
            }
            return Ok(user1);
        }

        [HttpPost("Register")]
        public ActionResult Register([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            var users = _user.GetUsers();
            var user = users.FirstOrDefault(x => x.Email == userObj.Email);
            if (user != null)
            {
                return BadRequest(new { message = "User Already exists !" });
            }
            _user.Add(userObj);
            _user.SaveChanges();
            return Ok(new { message = "User Registered Successfully !" });
        }

        private string CreateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.SerialNumber,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name)

            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
