using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System.Collections;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services
{
    public class EquipmentReservationService : IEquipmentReservationService
    {
        private readonly EquipmentReservationRepository _equipmentReservationRepository;

        public EquipmentReservationService(EquipmentReservationRepository equipmentReservationRepository)
        {
            _equipmentReservationRepository = equipmentReservationRepository;
 
        }

        public IEnumerable<EquipmentReservationDTO> GetAvailableAppointments(int equipmentId) 
        {
            IEnumerable<EquipmentReservation> allReservations = _equipmentReservationRepository.GetAll();

            IEnumerable<EquipmentReservation> available = allReservations
                .Where(reservation => reservation.EquipmentId == equipmentId && reservation.HospitalWorkerId == null);

            IEnumerable<EquipmentReservationDTO> availableDTOs = available
                .Select(reservation => MapToEquipmentReservationDTO(reservation));

            return availableDTOs;
        }

        public void CreateReservation(int equipmentReservationId, int hospitalWorkerId) 
        {
            var reservation = _equipmentReservationRepository.Get(equipmentReservationId);

            reservation.HospitalWorkerId = hospitalWorkerId;

            _equipmentReservationRepository.Update(reservation);
        }

        public IEnumerable<EquipmentReservationDTO> GetReservationsHistory(int hospitalWorkerId)
        {

            var reservationsHistory = _equipmentReservationRepository.GetByHospitalWorkerId(hospitalWorkerId)
                .Where(reservation => reservation.DateTime < DateTime.Now)
                .Select(MapToEquipmentReservationDTO);

            return reservationsHistory;
        }

        public IEnumerable<EquipmentReservationDTO> GetUpcomingReservations(int hospitalWorkerId)
        {

            var upcomingReservations = _equipmentReservationRepository.GetByHospitalWorkerId(hospitalWorkerId)
                .Where(reservation => reservation.DateTime > DateTime.Now)
                .Select(MapToEquipmentReservationDTO);

            return upcomingReservations;
        }

        private EquipmentReservationDTO MapToEquipmentReservationDTO(EquipmentReservation reservation)
        {
            EquipmentReservationDTO reservationDTO = new EquipmentReservationDTO
            {
                Id = reservation.Id,
                Date = reservation.DateTime.ToShortDateString(),
                Time = reservation.DateTime.ToShortTimeString(),
                Duration = reservation.Duration,
                EquipmentId = reservation.EquipmentId,
                HospitalWorkerId = reservation.HospitalWorkerId,
                CompanyAdminId = reservation.CompanyAdministratorId
            };

            return reservationDTO;
        }

         
    }
}
