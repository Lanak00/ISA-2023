using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentResponseDTO> GetEquipment(int? supplyCompanyId, string? name, string? type, SortEquipmentBy? sortBy, SortOrder? sortOrder);
    }
}
