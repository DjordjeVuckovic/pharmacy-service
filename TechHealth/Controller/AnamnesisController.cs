using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
    public class AnamnesisController
    {
        private readonly AnamnesisService anamnesisService = new AnamnesisService();
        public Anamnesis GetByAppointmentId(string appointmentId)
        {
            return anamnesisService.GetByAppointmentId(appointmentId);
        }
    }
}