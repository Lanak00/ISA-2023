using MedicalEquipmentSupplySystem.BussinessLogic.Services.Email;


namespace MedicalEquipmentSupplySystem.BussinessLogic.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailRequest emailRequest);
    }
}
