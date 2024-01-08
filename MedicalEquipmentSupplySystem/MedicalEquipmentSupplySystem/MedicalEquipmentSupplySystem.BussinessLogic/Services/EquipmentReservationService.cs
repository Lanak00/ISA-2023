using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System.Collections;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services
{
    public class EquipmentReservationService : IEquipmentReservationService
    {
        private readonly EquipmentReservationRepository _equipmentReservationRepository;
        public EquipmentReservationService(EquipmentReservationRepository equipmentReservationRepository) => _equipmentReservationRepository = equipmentReservationRepository;

        public IEnumerable<EquipmentReservation> GetAvailableAppointments(int equipmentId) 
        {
            IEnumerable<EquipmentReservation> allReservations = _equipmentReservationRepository.GetAll();

            IEnumerable<EquipmentReservation> available = allReservations
                .Where(reservation => reservation.EquipmentId == equipmentId && reservation.HospitalWorkerId == null);

            return available;
        }

        public void CreateReservation(int equipmentReservationId, int hospitalWorkerId) 
        {
            var reservation = _equipmentReservationRepository.Get(equipmentReservationId);

            reservation.HospitalWorkerId = hospitalWorkerId;

            _equipmentReservationRepository.Update(reservation);
        }
    }
}
