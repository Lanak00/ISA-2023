using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository) 
        {
            _userRepository = userRepository;   
        }

        public HospitalWorkerResponseDTO GetHospitalWorker(int hospitalWorkerId)
        {
            var hospitalWorker = _userRepository.GetHospitalWorker(hospitalWorkerId);
            return new HospitalWorkerResponseDTO()
            {
                FirstName = hospitalWorker.FirstName,
                LastName = hospitalWorker.LastName,
                Email = hospitalWorker.Email,
                Address = hospitalWorker.Address,
                City = hospitalWorker.City,
                Country = hospitalWorker.Country,
                Gender = hospitalWorker.Gender.ToString(),
                Company = hospitalWorker.Company,
                Penalties = hospitalWorker.Penalties
            };
        }
    }
}
