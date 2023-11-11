using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class HospitalWorker : User
    {
        public HospitalWorker() => this.Role = UserRole.HospitalWorker;
        public string Company { get; set; }
        public int Penalties { get; set; } = 0;
        public IEnumerable<EquipmentReservation> EquipmentReservationList { get; set; }

     
    }
}
