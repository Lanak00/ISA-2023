using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using UserRole = MedicalEquipmentSupplySystem.BussinessLogic.DTO.UserRole;

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
                Penalties = hospitalWorker.Penalties,
                IsVerified = hospitalWorker.IsValidated
            };
        }

        public UserDetailsDTO GetUser(int id)
        {
            var user = _userRepository.Get(id);
            int p = 0;

            if (user != null)
            {
                if ((int)user.Role == (int)UserRole.HospitalWorker)
                {
                    var hospitalWorker = _userRepository.GetHospitalWorker(user.Id);
                    p = hospitalWorker.Penalties;
                }

                return new UserDetailsDTO()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    City = user.City,
                    Email = user.Email,
                    Role = getUserRole(user),
                    Penalties = p
                };
            }
            else { return new UserDetailsDTO(); }
        }

        private string getUserRole(User user)
        {
            switch (user.Role)
            {
                case (DataAccess.Model.UserRole)UserRole.HospitalWorker:
                    return "Hospital Worker";
                case (DataAccess.Model.UserRole)UserRole.CompanyAdministrator:
                    return "Center Administrator";
                case (DataAccess.Model.UserRole)UserRole.SystemAdministrator:
                    return "System Administrator";
                default:
                    return "Unknown Role";
            }
        }
    }
}
