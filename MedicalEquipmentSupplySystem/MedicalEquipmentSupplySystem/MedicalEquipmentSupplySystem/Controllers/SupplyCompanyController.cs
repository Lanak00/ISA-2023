using Microsoft.AspNetCore.Mvc;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;


namespace MedicalEquipmentSupplySystem.API.Controllers
{

    [ApiController]
    [Route("supplyCompanies")]
    public class SupplyCompanyController : ControllerBase
    {
        private readonly ISupplyCompanyService _supplyCompanyService;

        public SupplyCompanyController(ISupplyCompanyService supplyCompanyService)
        {
            _supplyCompanyService = supplyCompanyService;
        }

        [HttpGet]
        public ActionResult GetAll(string? name, string? city, SortSupplyCompaniesBy? sortBy, SortOrder? sortOrder) 
        {
            var supplyCompanies = _supplyCompanyService.GetSupplyCompanies(name, city, sortBy, sortOrder);
            return Ok(supplyCompanies);
        }
    }
}
