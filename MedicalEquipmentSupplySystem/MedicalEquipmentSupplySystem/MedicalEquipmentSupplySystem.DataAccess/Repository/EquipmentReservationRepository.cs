using MedicalEquipmentSupplySystem.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
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
            var entry = _context.Entry(equipmentReservation);
            entry.State = EntityState.Modified;
            entry.Property("RowVersion").OriginalValue = equipmentReservation.RowVersion;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ApplicationException("Concurrency conflict: The data has been modified by another user.", ex);
            }
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
        public byte[] GetCurrentRowVersion(int reservationId)
        {
            return _context.EquipmentReservation
                .Where(e => e.Id == reservationId)
                .Select(e => e.RowVersion)
                .FirstOrDefault();
        }
    }
}
