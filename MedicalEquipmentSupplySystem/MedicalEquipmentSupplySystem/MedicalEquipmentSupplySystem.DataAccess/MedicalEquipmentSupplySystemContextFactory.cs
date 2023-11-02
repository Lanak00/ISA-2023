using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentSupplySystem.DataAccess
{
    public class MedicalEquipmentSupplySystemContextFactory : IDesignTimeDbContextFactory<MedicalEquipmentSupplySystemDbContext>
    {
        public MedicalEquipmentSupplySystemDbContext CreateDbContext(string[] args)
        {
            string connectionString = args[0];
            var optionsBuilder = new DbContextOptionsBuilder<MedicalEquipmentSupplySystemDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            var context = new MedicalEquipmentSupplySystemDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
