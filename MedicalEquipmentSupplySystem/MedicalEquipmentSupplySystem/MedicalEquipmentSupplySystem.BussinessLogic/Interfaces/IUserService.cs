using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface IUserService
    {
        HospitalWorkerResponseDTO GetHospitalWorker(int hospitalWorkerId);
        void InsertHospitalWorker(HospitalWorkerRegisterDTO hospitalWorker);
    }
}
