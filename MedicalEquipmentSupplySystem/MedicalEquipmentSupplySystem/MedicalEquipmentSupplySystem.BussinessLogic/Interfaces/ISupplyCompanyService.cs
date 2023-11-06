using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface ISupplyCompanyService
    {
        IEnumerable<SupplyCompanyResponseDTO> GetSupplyCompanies(string? name, string? city, SortSupplyCompaniesBy? sortBy, SortOrder? sortOrder);
    }
}
