using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Controller.IController
{
    public interface IAnamnesisController:IController<Anamnesis,string>
    {
        Anamnesis GetByAppointmentId(string appointmentId);
        List<Anamnesis> GetAllAnamnesisExaminationsByPatient(string patientId);
        List<Anamnesis> GetAllAnamnesisSurgeriesByPatient(string patientId);
        List<Anamnesis> GetAllAnamnesisByDate(string patientId, DateTime startDate, DateTime finishDate);
    }
}