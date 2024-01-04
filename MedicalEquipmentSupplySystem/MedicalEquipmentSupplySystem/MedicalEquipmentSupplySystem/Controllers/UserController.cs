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

        [HttpGet("users/{id}")]
        public ActionResult GetUser(int id)
        {
            var userDetails = _userService.GetUser(id);

            if (userDetails == null)
            {
                return NotFound(); // User not found
            }

            return Ok(userDetails);
        }


    }
}
