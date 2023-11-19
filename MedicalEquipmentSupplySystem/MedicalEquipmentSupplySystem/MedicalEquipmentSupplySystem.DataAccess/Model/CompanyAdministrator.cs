using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class CompanyAdministrator : User
    {
        public int? SupplyCompanyId { get; set; }

        public IEnumerable<Complaint> Complaints { get; set; }

    }
}
