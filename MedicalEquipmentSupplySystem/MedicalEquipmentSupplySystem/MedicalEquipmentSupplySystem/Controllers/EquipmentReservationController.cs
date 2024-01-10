using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalEquipmentSupplySystem.API.Controllers
{

    [ApiController]
    [Route("reservations")]
    public class EquipmentReservationController : ControllerBase
    {
        private readonly IEquipmentReservationService _equipmentReservationService;

        public EquipmentReservationController(IEquipmentReservationService equipmentReservationService)
        {
            _equipmentReservationService = equipmentReservationService;
        }

        [HttpGet("available")]
        public ActionResult GetAvailableAppointments(int equipmentId)
        {
            var available = _equipmentReservationService.GetAvailableAppointments(equipmentId);
            return Ok(available);
        }

        [HttpGet("history")]
        public ActionResult GetReservationsHistory(int hospitalWorkerId)
        {
            var history = _equipmentReservationService.GetReservationsHistory(hospitalWorkerId);
            return Ok(history);
        }

        [HttpGet("upcoming")]
        public ActionResult GetUpcomingReservations(int hospitalWorkerId)
        {
            var upcoming = _equipmentReservationService.GetUpcomingReservations(hospitalWorkerId);
            return Ok(upcoming);
        }

        [HttpPost("reserve")]
        public IActionResult CreateReservation(int equipmentReservationId, int hospitalWorkerId, string email)
        {
            try
            {
                _equipmentReservationService.CreateReservation(equipmentReservationId, hospitalWorkerId, email);
                return Ok("Reservation created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("cancel")]
        public IActionResult CancelReservation(int equipmentReservationId)
        {
            try
            {
                _equipmentReservationService.CancelReservation(equipmentReservationId);
                return Ok("Reservation canceled successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
