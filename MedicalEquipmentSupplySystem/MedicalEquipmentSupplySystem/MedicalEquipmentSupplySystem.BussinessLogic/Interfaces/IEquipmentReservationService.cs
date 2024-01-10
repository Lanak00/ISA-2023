using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface IEquipmentReservationService
    {
        public IEnumerable<EquipmentReservationDTO> GetAvailableAppointments(int equipmentId);
        public void CreateReservation(int equipmentReservationId, int hospitalWorkerId, string email);
        public IEnumerable<EquipmentReservationDTO> GetReservationsHistory(int hospitalWorkerId);
        public IEnumerable<EquipmentReservationDTO> GetUpcomingReservations(int hospitalWorkerId);
    }
}
