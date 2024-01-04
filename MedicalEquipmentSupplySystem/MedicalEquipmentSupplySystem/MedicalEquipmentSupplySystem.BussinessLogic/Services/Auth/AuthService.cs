using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.DTO.HospitalWorker;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System.Security.Cryptography;

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
                Password = PasswordStorage.CreateHash(user.Password),
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Gender = (DataAccess.Model.Gender)user.Gender,
                IsValidated = false,
                Company = user.Company,
                Role = 0,
                VerificationToken = CreateRandomToken()
            };

            var id = _userRepository.AddHospitalWorker(hospitalWorker);
            return new Register() { RegisterResult = RegisterResult.Success, Id = id };
        }

        public bool VerifyUser(string token)
        {
            var user = _userRepository.GetByCondition(x => x.VerificationToken == token).FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            else {
                user.IsValidated = true;
                _userRepository.Update(user);
                return true;
            }
        }

        public string GetToken(string email)
        {
            var user = _userRepository.GetByCondition(x => x.Email == email).FirstOrDefault();
            return user.VerificationToken;
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        }

        public bool Authenticate(string email, string password)
        {
            var user = _userRepository.GetByCondition(x => x.Email == email).FirstOrDefault();

            if (user == null)
            {
                return false; // User with given email doesn't exist
            }

            if (PasswordStorage.VerifyPassword(password, user.Password))
            {
                return true; // Authentication successful
            }

            return false; // Password verification failed
        }


        public UserDetailsDTO GetUserDetailsByEmail(string email)
        {
            var user = _userRepository.GetByCondition(x => x.Email == email).FirstOrDefault();

            if (user == null)
            {
                return null; // throw exception
            }

            return new UserDetailsDTO
            {
                Id = user.Id,
                Role = getUserRole(user),
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsVerified = user.IsValidated
            };
        }

        private string getUserRole(User user)
        {
            switch (user.Role)
            {
                case (DataAccess.Model.UserRole)UserRole.HospitalWorker:
                    return "HospitalWorker";
                case (DataAccess.Model.UserRole)UserRole.CompanyAdministrator:
                    return "CenterAdministrator";
                case (DataAccess.Model.UserRole)UserRole.SystemAdministrator:
                    return "SystemAdministrator";
                default:
                    return "Unknown Role";
            }
        }
    }

}

