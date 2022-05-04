using System.Collections.Generic;
using TechHealth.Model;
using System;

namespace TechHealth.Service.RecommendationService
{
    interface ITransformDraftToAppointment
    {
        List<Appointment> TransformDraftToAppointment(List<AppointmentDraft> recommendedAppointmentDrafts,string patientID, string doctorID);
    }
}

