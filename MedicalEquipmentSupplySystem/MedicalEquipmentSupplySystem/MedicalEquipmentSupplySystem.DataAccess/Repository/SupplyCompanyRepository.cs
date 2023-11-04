using MedicalEquipmentSupplySystem.DataAccess.Model;
using System.Linq.Expressions;

namespace MedicalEquipmentSupplySystem.DataAccess.Repository
{
    public class SupplyCompanyRepository
    {
        private readonly MedicalEquipmentSupplySystemDbContext _context;
        public SupplyCompanyRepository(MedicalEquipmentSupplySystemDbContext context) => _context = context;

        public SupplyCompany Get(int id) => _context.SupplyCompanies.Find(id);

        public IEnumerable<SupplyCompany> GetAll() => _context.SupplyCompanies;

        public void Update(SupplyCompany supplyCompany)
        {
            _context.SupplyCompanies.Update(supplyCompany);
            _context.SaveChanges();
        }

        public int Add(SupplyCompany supplyCompany)
        {
            _context.SupplyCompanies.Add(supplyCompany);
            _context.SaveChanges();
            return supplyCompany.Id;
        }

        public IEnumerable<SupplyCompany> GetByCondition(Expression<Func<SupplyCompany, bool>> expression)
        {
            return _context.SupplyCompanies.Where(expression.Compile());
        }
    }
}
