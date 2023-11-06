using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System.Linq.Expressions;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services
{

    public enum SortSupplyCompaniesBy
    {
        Name,
        City,
        Rating
    }

    public enum  SortOrder
    {
        Asc,
        Desc
    }

    public class SupplyCompanyService : ISupplyCompanyService
    {
        private readonly SupplyCompanyRepository _supplyCompanyRepository;

        public SupplyCompanyService(SupplyCompanyRepository supplyCompanyRepository)
        {
            _supplyCompanyRepository = supplyCompanyRepository;
        }

        public IEnumerable<SupplyCompanyResponseDTO> GetSupplyCompanies(string? name, string? city, SortSupplyCompaniesBy? sortBy, SortOrder? sortOrder)
        {
            List<Predicate<SupplyCompany>> conditions = new();

            if (name != null)
                conditions.Add(x => x.Name.ToLower().Contains(name.ToLower()));
            if (city != null)
                conditions.Add(X => X.City.ToLower().Contains(city.ToLower()));

            Expression<Func<SupplyCompany, bool>> expression = c => conditions.All(pred => pred(c));

            var supplyCompanies = _supplyCompanyRepository.GetByCondition(expression);

            if (sortBy == SortSupplyCompaniesBy.Name)
                supplyCompanies = sortOrder == SortOrder.Asc ?
                    supplyCompanies.OrderBy(x => x.Name) : supplyCompanies.OrderByDescending(x => x.Name);
            else if (sortBy == SortSupplyCompaniesBy.City)
                supplyCompanies = sortOrder == SortOrder.Asc ?
                    supplyCompanies.OrderBy(x => x.City) : supplyCompanies.OrderByDescending(x => x.City);
            else if (sortBy == SortSupplyCompaniesBy.Rating)
                supplyCompanies = sortOrder == SortOrder.Asc ?
                    supplyCompanies.OrderBy(x => x.Rating) : supplyCompanies.OrderByDescending(x => x.Rating);

            return supplyCompanies.Select(x => new SupplyCompanyResponseDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Image = x.Image,
                Description = x.Description,
                Rating = x.Rating
            });
        }
    }
}
