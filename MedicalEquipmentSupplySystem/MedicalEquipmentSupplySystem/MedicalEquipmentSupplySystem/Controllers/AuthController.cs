using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentSupplySystem.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<Guid> Register(HospitalWorkerRegisterDTO user)
        {
            var result = _authService.RegisterHospitalWorker(user);
            if (result.RegisterResult == RegisterResult.Success)
                return Created("auth/register/", new { id = result.Id.ToString() });

            return BadRequest("User already exists");
        }
    }
}
