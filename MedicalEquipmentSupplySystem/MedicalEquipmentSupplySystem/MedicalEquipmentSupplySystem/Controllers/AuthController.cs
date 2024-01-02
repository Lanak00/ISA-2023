using MailKit;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalEquipmentSupplySystem.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IConfiguration configuration, IAuthService authService, IEmailService emailService)
        {
            _configuration = configuration;
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(HospitalWorkerRegisterDTO user)
        {
            var result = _authService.RegisterHospitalWorker(user);

            if (result.RegisterResult != RegisterResult.Success)
            {
                return BadRequest("User already exists");
            }



            var request = new EmailRequest();
            request.ToEmail = user.Email;
            request.Subject = "Registration verification";
            request.Body = _authService.GetToken(user.Email);

            try
            {
                _emailService.SendEmail(request);
                return Created("auth/register/", new { id = result.Id.ToString() });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify(string token)
        {
            if (!_authService.VerifyUser(token))
            {
                return BadRequest("Invalid Token");
            }

            return Ok("User verified! :)");


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            bool isAuthenticated = _authService.Authenticate(login.Email, login.Password);

            if (!isAuthenticated)
            {
                return Unauthorized("Invalid credentials");
            }

            var userDetails = _authService.GetUserDetailsByEmail(login.Email);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userDetails.Id.ToString()), 
                new Claim(ClaimTypes.Role, userDetails.Role.ToString()), 
                new Claim("FirstName", userDetails.FirstName), 
                new Claim("LastName", userDetails.LastName) 
            };

            // Token configuration
            var key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpiresInDays"])),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { Token = tokenString });
        }

    }

}
