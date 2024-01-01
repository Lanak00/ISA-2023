using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.DTO
{

    public enum UserRole
    {
        HospitalWorker,
        CompanyAdministrator,
        SystemAdministrator
    }

    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public UserRole Role { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
