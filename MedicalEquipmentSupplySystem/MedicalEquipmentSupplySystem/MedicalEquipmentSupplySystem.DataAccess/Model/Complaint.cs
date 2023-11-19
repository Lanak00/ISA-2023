using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class Complaint
    {
        public int id { get; set; }
        public string body { get; set; }
        public HospitalWorker HospitalWorker { get; set; }
        public int HospitalWorkerId { get; set; }
        public CompanyAdministrator? CompanyAdministrator { get; set; } = null;
        public int? CompanyAdministratorId { get; set;}
        public SupplyCompany? SupplyCompany { get; set; } = null;
        public int? SupplyCompanyId { get;set; }
    }
}
