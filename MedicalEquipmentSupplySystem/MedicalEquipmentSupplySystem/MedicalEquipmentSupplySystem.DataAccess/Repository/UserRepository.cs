using MedicalEquipmentSupplySystem.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Repository
{
    public class UserRepository
    {
        private readonly MedicalEquipmentSupplySystemDbContext _context;

        public UserRepository(MedicalEquipmentSupplySystemDbContext context) => _context = context;

        public User Get(int id) => _context.Users.Find(id);

        public HospitalWorker GetHospitalWorker(int id) => _context.HospitalWorkers.Find(id);

        public void UpdateHospitalWorker(HospitalWorker hospitalWorker)
        {
            _context.HospitalWorkers.Update(hospitalWorker);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetByCondition(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression.Compile());
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public int AddHospitalWorker(HospitalWorker hospitalWorker)
        {
            _context.HospitalWorkers.Add(hospitalWorker);
            _context.SaveChanges();
            return hospitalWorker.Id;
        }

        public int AddCenterAdministrator(CompanyAdministrator centerAdministrator)
        {
            throw new NotImplementedException();
        }

        public int AddSystemAdministrator(SystemAdministrator systemAdministrator)
        {
            throw new NotImplementedException();
        }
    }
}
