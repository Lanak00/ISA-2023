using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface IAuthService
    {
        public Register RegisterHospitalWorker(HospitalWorkerRegisterDTO user);
        public bool VerifyUser(string token);
        public string GetToken(string email);
    }
}
