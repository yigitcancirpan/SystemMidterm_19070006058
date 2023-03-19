using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SystemMidterm_19070006058.Model;
using SystemMidterm_19070006058.Model.Dto;
using SystemMidterm_19070006058.Source;

namespace SystemMidterm_19070006058.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        /// <summary>
        /// Authenticates user and generates JWT token
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.GivenName, user.GivenName),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.Role, user.Role)
                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLoginDto userLogin)
        {
            var currentUser = _userService.TGetAll().FirstOrDefault(o => o.Username.ToLower() == userLogin.Username.ToLower() && o.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
