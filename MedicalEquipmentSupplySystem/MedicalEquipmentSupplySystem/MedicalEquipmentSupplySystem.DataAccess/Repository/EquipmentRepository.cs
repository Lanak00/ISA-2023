using MedicalEquipmentSupplySystem.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Repository
{
    public class EquipmentRepository
    {
        private readonly MedicalEquipmentSupplySystemDbContext _context;
        public EquipmentRepository(MedicalEquipmentSupplySystemDbContext context) => _context = context;

        public void Update(Equipment equipment)
        {
            _context.Equipment.Update(equipment);
            _context.SaveChanges();
        }
        
        public int Add(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
            return equipment.Id;
        }

        public IEnumerable<Equipment> GetAll() => _context.Equipment;

        public Equipment GetEquipment(int equipmentId) => _context.Equipment.Find(equipmentId);

        public IEnumerable<Equipment> GetByCondition(Expression<Func<Equipment, bool>> expression) 
        {
            return _context.Equipment
                .Include(x => x.SupplyCompany)
                .Where(expression.Compile());
        }
    }
}
