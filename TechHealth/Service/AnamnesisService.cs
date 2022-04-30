using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class AnamnesisService
    {
        public Anamnesis GetByAppointmentId(string appointmentId)
        {
          var anamnesis = AnamnesisRepository.Instance.GetByAppointmentId(appointmentId);
          BindDataForAnamnesis(anamnesis);
          return anamnesis;
        }

        private void BindDataForAnamnesis(Anamnesis anamneses)
        {
            
            anamneses.AnmnesisAppointment = AppointmentRepository.Instance.GetById(anamneses.AnmnesisAppointment.IdAppointment);
            
        }
    }
}