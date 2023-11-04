using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface ISupplyCompanyService
    {
        IEnumerable<SupplyCompany> GetSupplyCompanies(string? name, string? city, SortSupplyCompaniesBy? sortBy, SortOrder? sortOrder);
    }
}
