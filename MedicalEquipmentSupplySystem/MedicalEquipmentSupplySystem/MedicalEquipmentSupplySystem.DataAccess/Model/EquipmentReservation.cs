using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class EquipmentReservation 
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Duration { get; set; }
        public Equipment Equipment { get; set; }
        public Guid EquipmentId { get; set; }
        public HospitalWorker HospitalWorker { get; set; }
        public Guid HospitalWorkerId { get; set; }
        public SystemAdministrator SystemAdministrator { get; set; }
        public Guid SystemAdministratorId { get; set; }

    }
}
