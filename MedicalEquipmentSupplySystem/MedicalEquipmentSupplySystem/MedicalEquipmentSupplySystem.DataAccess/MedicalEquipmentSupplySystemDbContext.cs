using MedicalEquipmentSupplySystem.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicalEquipmentSupplySystem.DataAccess
{
    internal class MedicalEquipmentSupplySystemDbContext : DbContext
    {
        public MedicalEquipmentSupplySystemDbContext() { }

        public MedicalEquipmentSupplySystemDbContext(DbContextOptions<MedicalEquipmentSupplySystemDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<SupplyCompany> SupplyCompanies { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>(x =>
            {

                x.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4");
                x.HasKey(x => x.Id);
                x.Property(x => x.FirstName).IsRequired(true);
                x.Property(x => x.LastName).IsRequired(true);
                x.Property(x => x.Email).IsRequired(true);
                x.Property(x => x.Password).IsRequired(true);
                x.Property(x => x.Address).IsRequired(true);
                x.Property(x => x.City).IsRequired(true);
                x.Property(x => x.Country).IsRequired(true);
            });
        }
    }
}