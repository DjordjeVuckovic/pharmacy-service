using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Service.IService
{
    public interface IAnamnesisService:IService<Anamnesis,string>
    {
        List<Anamnesis> GetAllAnamnesisSurgeriesByPatient(string patientId);
        Anamnesis GetByAppointmentId(string appointmentId);
        List<Anamnesis> GetAllAnamnesisExaminationsByPatient(string patientId);
        List<Anamnesis> GetAllAnamnesisByPatientId(string patientId);
        List<Anamnesis> GetAllAnamnesisByDate(string patientId, DateTime startDate, DateTime finishDate);

    }
}