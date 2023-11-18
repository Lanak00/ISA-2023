using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services
{
    public enum SortEquipmentBy
    {
        Name,
        Type
    }

    public class EquipmentService : IEquipmentService
    {
        private readonly EquipmentRepository _equipmentRepository;

        public EquipmentService(EquipmentRepository equipmentRepository) => _equipmentRepository = equipmentRepository;


        public IEnumerable<EquipmentResponseDTO> GetEquipment(int? supplyCompanyId, string? name, string? type, SortEquipmentBy? sortBy, SortOrder? sortOrder)
        {
            List<Predicate<Equipment>> conditions = new();

            if (supplyCompanyId != null)
                conditions.Add(x => x.SupplyCompany.Id == supplyCompanyId);
            if (name != null)
                conditions.Add(x => x.Name.ToLower().Contains(name.ToLower()));
            if (type != null)
                conditions.Add(x => x.Type.ToLower().Contains(type.ToLower()));

            Expression<Func<Equipment, bool>> expression = c => conditions.All(pred => pred(c));

            var equipment = _equipmentRepository.GetByCondition(expression);

            if (sortBy == SortEquipmentBy.Name)
                equipment = sortOrder == SortOrder.Asc ?
                    equipment.OrderBy(x => x.Name) : equipment.OrderByDescending(x => x.Name);
            else if (sortBy == SortEquipmentBy.Type)
                equipment = sortOrder == SortOrder.Asc ?
                    equipment.OrderBy(x => x.Type) : equipment.OrderByDescending(x => x.Type);

            return equipment.Select(x => new EquipmentResponseDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Description = x.Description
            });
        }
    }
}
