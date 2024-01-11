using MedicalEquipmentSupplySystem.BussinessLogic.DTO;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;
using MedicalEquipmentSupplySystem.DataAccess.Model;
using MedicalEquipmentSupplySystem.DataAccess.Repository;
using System.Net.Mail;
using QRCoder;
using System.Drawing;
using System.IO;
using MimeKit;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services
{
    public class EquipmentReservationService : IEquipmentReservationService
    {
        private readonly EquipmentReservationRepository _equipmentReservationRepository;
        private readonly IEmailService _emailService;
        private readonly UserRepository _userRepository;
        private readonly EquipmentRepository _equipmentRepository;

        public EquipmentReservationService(EquipmentReservationRepository equipmentReservationRepository, IEmailService emailService, UserRepository userRepository, EquipmentRepository equipmentRepository)
        {
            _equipmentReservationRepository = equipmentReservationRepository;
            _emailService = emailService;
            _userRepository = userRepository;
            _equipmentRepository = equipmentRepository;
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

        public void CreateReservation(int equipmentReservationId, int hospitalWorkerId, string email) 
        {
            var reservation = _equipmentReservationRepository.Get(equipmentReservationId);

            reservation.HospitalWorkerId = hospitalWorkerId;

            _equipmentReservationRepository.Update(reservation);

            /*generisanje QR koda i slanje mejla*/

            var qrCodeBytes = GenerateQRCodeAsBytes(reservation);

            // Compose email
            var emailRequest = new EmailRequest();
            emailRequest.ToEmail = email;
            emailRequest.Subject = "Reservation Confirmation";
            emailRequest.Body = "Thank you for your reservation. Scan QR code to see your reservation details:\n"; 

            emailRequest.Attachments.Add(new MimePart("image", "png")
            {
                Content = new MimeContent(new MemoryStream(qrCodeBytes), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = "QRCode.png"
            });

            try
            {
                _emailService.SendEmail(emailRequest);
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public void CancelReservation(int equipmentReservationId)
        {
            var equipmentReservation = _equipmentReservationRepository.Get(equipmentReservationId);

            var hospitalWorker = _userRepository.GetHospitalWorker((int)equipmentReservation.HospitalWorkerId);
           

            equipmentReservation.HospitalWorkerId = null;

            TimeSpan timeDifference = equipmentReservation.DateTime - DateTime.Now;

            if (timeDifference.TotalHours > 24)
            {
                hospitalWorker.Penalties++;
            }
            else
            {
                hospitalWorker.Penalties += 2;
            }

            _equipmentReservationRepository.Update(equipmentReservation);
            _userRepository.UpdateHospitalWorker(hospitalWorker);
        }

        private EquipmentReservationDTO MapToEquipmentReservationDTO(EquipmentReservation reservation)
        {
            var equipment = _equipmentRepository.GetEquipment(reservation.EquipmentId);

            EquipmentReservationDTO reservationDTO = new EquipmentReservationDTO
            {
                Id = reservation.Id,
                Date = reservation.DateTime.ToShortDateString(),
                Time = reservation.DateTime.ToShortTimeString(),
                Duration = reservation.Duration,
                EquipmentId = reservation.EquipmentId,
                HospitalWorkerId = reservation.HospitalWorkerId,
                CompanyAdminId = reservation.CompanyAdministratorId,
                EquipmentName = equipment.Name
            };

            return reservationDTO;
        }

        private byte[] GenerateQRCodeAsBytes(EquipmentReservation reservation)
        {
            var qrContent = $"Equipment: {reservation.Equipment.Name}\n" +
                     $"Date: {reservation.DateTime.ToShortDateString()}\n" +
                     $"Time: {reservation.DateTime.ToShortTimeString()}\n" +
                     $"Duration: {reservation.Duration + " " + "hours"} \n";

            using var qrGenerator = new QRCoder.QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCoder.PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20); // Get QR code image as byte array
        }
    }
}
