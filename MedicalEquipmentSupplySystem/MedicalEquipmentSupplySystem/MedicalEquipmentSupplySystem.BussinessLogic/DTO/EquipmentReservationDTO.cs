using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.DTO
{
    public class EquipmentReservationDTO
    {
        public int Id {get; set;}
        public string Date { get; set;}
        public string Time { get; set;}
        public int Duration { get; set; }
        public int EquipmentId { get; set; }
        public int? HospitalWorkerId { get; set; }
        public int CompanyAdminId { get; set; }
    }
}
