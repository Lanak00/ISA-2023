using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
