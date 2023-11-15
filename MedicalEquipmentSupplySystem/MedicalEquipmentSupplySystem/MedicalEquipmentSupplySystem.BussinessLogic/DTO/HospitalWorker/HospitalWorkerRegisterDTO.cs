using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class HospitalWorkerRegisterDTO
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }    
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public string Company { get; set; }
    }
}
