using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set;}
        public SupplyCompany SupplyCompany { get; set; }
        public int SupplyCompanyId { get; set; }

        public IEnumerable<EquipmentReservation> equipmentReservations { get; set; }

    }
}
