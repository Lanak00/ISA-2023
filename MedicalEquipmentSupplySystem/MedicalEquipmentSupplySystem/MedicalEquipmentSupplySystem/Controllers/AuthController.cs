using MailKit;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

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


       /* [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromForm] EmailRequest request)
        {
            try
            {
                _emailService.SendEmail(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/

    }

}
