using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum UserRole
    {
        HospitalWorker,
        CenterAdministrator,
        SystemAdministrator
    }

    public class HospitalWorkerRegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }    
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public string Company { get; set; }
        public int Penalties { get; set; }
    }
}
