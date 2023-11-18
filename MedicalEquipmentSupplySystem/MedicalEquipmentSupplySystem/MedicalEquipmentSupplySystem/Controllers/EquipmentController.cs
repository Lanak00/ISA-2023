using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentSupplySystem.API.Controllers
{
    [ApiController]
    [Route("equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public ActionResult GetCompanyEquipment(int? supplyCompanyId, string? name, string? type, SortEquipmentBy? sortBy, SortOrder? sortOrder) 
        {
            var equipment = _equipmentService.GetEquipment(supplyCompanyId, name, type, sortBy, sortOrder);
            return Ok(equipment);
        }
    }
}
