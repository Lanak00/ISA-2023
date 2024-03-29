﻿using System.Numerics;

namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum UserRole
    {
        HospitalWorker,
        CompanyAdministrator,
        SystemAdministrator
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public bool IsValidated { get; set; }
        public string? VerificationToken { get; set; }

    }
}
