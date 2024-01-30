using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class EquipmentReservation 
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }
        public HospitalWorker? HospitalWorker { get; set; } = null;
        public int? HospitalWorkerId { get; set; } 
        public CompanyAdministrator CompanyAdministrator { get; set; }
        public int CompanyAdministratorId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
