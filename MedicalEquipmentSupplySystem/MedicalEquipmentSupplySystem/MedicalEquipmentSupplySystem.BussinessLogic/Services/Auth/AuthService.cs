using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services.Auth
{
    public enum RegisterResult
    {
        Success,
        UserAlreadyExists
    }

    public enum UserRole
    {
        HospitalWorker,
        CompanyAdministrator,
        SystemAdministrator,
        Unknown
    }

    public class Register
    {
        public RegisterResult RegisterResult { get; set; }
        public int Id { get; set; }
    }

    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Register RegisterHospitalWorker(HospitalWorkerRegisterDTO user)
        {
            var usr = _userRepository.GetByCondition(x => x.Email == user.Email).FirstOrDefault();
            if (usr != null) return new Register() { RegisterResult = RegisterResult.UserAlreadyExists, Id = 0 };

            var hospitalWorker = new HospitalWorker()
            {
                Id = new int(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Gender = (DataAccess.Model.Gender)user.Gender,
                IsValidated = false,
                Company = user.Company,
                Penalties = user.Penalties
            };

            var id = _userRepository.AddHospitalWorker(hospitalWorker);
            return new Register() { RegisterResult = RegisterResult.Success, Id = id };
        }
    }
}
