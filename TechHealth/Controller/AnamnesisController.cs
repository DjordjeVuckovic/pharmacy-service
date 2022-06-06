using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechHealth.Model;
using TechHealth.Service;
using TechHealth.Service.IService;

namespace TechHealth.Controller
{
    public class AnamnesisController
    {
        private readonly IAnamnesisService anamnesisService = new AnamnesisService();
        public Anamnesis GetByAppointmentId(string appointmentId) => anamnesisService.GetByAppointmentId(appointmentId);

        public void Create(Anamnesis anamnesis) => anamnesisService.Create(anamnesis);

        public void Update(Anamnesis anamnesis) => anamnesisService.Update(anamnesis);

        public List<Anamnesis> GetAllAnamnesisExaminationsByPatient(string patientId) => anamnesisService.GetAllAnamnesisExaminationsByPatient(patientId);

        public List<Anamnesis> GetAllAnamnesisSurgeriesByPatient(string patientId) => anamnesisService.GetAllAnamnesisSurgeriesByPatient(patientId);

        public List<Anamnesis> GetAllAnamnesisByDate(string patientId, DateTime startDate, DateTime finishDate) => anamnesisService.GetAllAnamnesisByDate(patientId, startDate, finishDate);
    }
}