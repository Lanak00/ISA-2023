using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services.Email
{
    public class EmailConfiguration
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }
}
