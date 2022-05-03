using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.RecommendationService
{
    interface ITransformDraftToAppointment
    {
        List<Appointment> TransformDraftToAppointment(List<AppointmentDraft> recommendedAppointmentDrafts, string PatientID, string DoctorID);
    }
}

