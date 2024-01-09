using MedicalEquipmentSupplySystem.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.DataAccess.Repository
{
    public  class EquipmentReservationRepository
    {
        private readonly MedicalEquipmentSupplySystemDbContext _context;
        public EquipmentReservationRepository(MedicalEquipmentSupplySystemDbContext context) => _context = context;

        public void Update(EquipmentReservation equipmentReservation)
        {
            _context.EquipmentReservation.Update(equipmentReservation);
            _context.SaveChanges();
        }

        public int Add(EquipmentReservation equipmentReservation)
        {
            _context.EquipmentReservation.Add(equipmentReservation);
            _context.SaveChanges();
            return equipmentReservation.Id;
        }

        public EquipmentReservation Get(int id) => _context.EquipmentReservation.Find(id);

        public IEnumerable<EquipmentReservation> GetAll() => _context.EquipmentReservation;

        public IEnumerable<EquipmentReservation> GetByHospitalWorkerId(int userId) {
            return _context.EquipmentReservation.Where(reservation => reservation.HospitalWorkerId == userId);
        }
    }
}
