using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentSupplySystem.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService; 
        }

        [HttpGet("hospitalWorkers/{id}")]
        public ActionResult Get(int id)
        {
            var hospitalWorker = _userService.GetHospitalWorker(id);
            return Ok(hospitalWorker);
        }
    }
}
