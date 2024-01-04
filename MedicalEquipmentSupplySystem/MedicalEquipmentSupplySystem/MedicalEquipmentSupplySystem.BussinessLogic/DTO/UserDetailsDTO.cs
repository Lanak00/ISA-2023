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
        public string Role { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Penalties { get; set; }
        public bool IsVerified { get; set; }
    }
}
