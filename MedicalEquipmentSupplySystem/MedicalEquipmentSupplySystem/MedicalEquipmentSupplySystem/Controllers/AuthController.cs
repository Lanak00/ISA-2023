using MailKit;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using Microsoft.AspNetCore.Mvc;

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
             if (result.RegisterResult == RegisterResult.Success)
             { 

                 return Created("auth/register/", new { id = result.Id.ToString() });
             }


            return BadRequest("User already exists");
        }

        [HttpPost("send")]
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

        }

    }

}
