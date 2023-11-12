using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace MedicalEquipmentSupplySystem.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IConfiguration config, IAuthService authService, IEmailService emailService)
        {
            _config = config;
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



      /*  [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email) 
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded) 
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { Status = "Success", Message = "Email Verified Successfully" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Err0r", Message = "This User does not exist" });
        }*/

    }

    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
