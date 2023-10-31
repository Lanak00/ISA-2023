namespace MedicalEquipmentSupplySystem.DataAccess.Model
{
    public class SupplyCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public byte[] Image { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }

        public IEnumerable<Equipment> Equipments { get; set; }
    }
}
