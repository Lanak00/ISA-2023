using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class CompanyAdministrator : User
    {
        public CompanyAdministrator() => this.Role = UserRole.CompanyAdministrator;

    }
}
