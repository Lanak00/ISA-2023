namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class SupplyCompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public byte[] Image { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }

        public IEnumerable<Equipment> equipmentList { get; set; }
        public IEnumerable<CompanyAdministrator> companyAdministrators { get; set; } 
    }
}
