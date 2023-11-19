using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class HospitalWorker : User
    {
        public string Company { get; set; }
        public int Penalties { get; set; } = 0;
        public IEnumerable<EquipmentReservation> EquipmentReservationList { get; set; }
        public IEnumerable<Complaint> Complaints { get; set; }
     
    }
}
