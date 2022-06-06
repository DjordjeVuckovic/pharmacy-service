using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class AnamnesisService:IAnamnesisService
    {
        public Anamnesis GetByAppointmentId(string appointmentId)
        {
          var anamnesis = AnamnesisRepository.Instance.GetByAppointmentId(appointmentId);
          BindDataForAnamnesis(anamnesis);
          return anamnesis;
        }

        private void BindDataForAnamnesis(Anamnesis anamneses)
        {
            
            anamneses.Appointment = AppointmentRepository.Instance.GetById(anamneses.Appointment.IdAppointment);
            
        }

        public List<Anamnesis> GetAll()
        {
            var anamneses = AnamnesisRepository.Instance.GetAllToList();
            BindDataForAnamneses(anamneses);
            return anamneses;
        }

        public bool Create(Anamnesis anamnesis)
        {
            return AnamnesisRepository.Instance.Create(anamnesis);
        }
        public bool Update(Anamnesis anamnesis)
        {
            return AnamnesisRepository.Instance.Update(anamnesis);
        }

        public Anamnesis GetById(string key)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<Anamnesis> GetAllAnamnesisSurgeriesByPatient(string patientId)
        {
            var anamneses = new List<Anamnesis>();
            foreach (var an in GetAll() )
            {
                if (an.Appointment != null && an.Appointment.AppointmentType == AppointmentType.operation && an.Appointment.Patient.Jmbg.Equals(patientId))
                {
                    anamneses.Add(an);
                    BindDataForAppointment(an.Appointment);
                }
            }
            return anamneses;
        }
        public List<Anamnesis> GetAllAnamnesisExaminationsByPatient(string patientId)
        {
            var anamneses = new List<Anamnesis>();
            foreach (var an in GetAll())
            {
                if (an.Appointment != null && an.Appointment.AppointmentType == AppointmentType.examination && an.Appointment.Patient.Jmbg.Equals(patientId))
                {
                    anamneses.Add(an);
                    BindDataForAppointment(an.Appointment);
                }
            }
            return anamneses;
        }
        public List<Anamnesis> GetAllAnamnesisByPatientId(string patientId)
        {
            var anamneses = new List<Anamnesis>();
            foreach (var an in GetAll())
            {
                if (an.Appointment != null && an.Appointment.Patient.Jmbg.Equals(patientId))
                {
                    anamneses.Add(an);
                    BindDataForAppointment(an.Appointment);
                }
            }
            return anamneses;
        }
        private void BindDataForAnamneses(List<Anamnesis> anamneses)
        {
            foreach (var an in anamneses)
            {
                an.Appointment = AppointmentRepository.Instance.GetById(an.Appointment.IdAppointment);
            }

        }

        private void BindDataForAppointment(Appointment appointment)
        {
            appointment.Doctor = DoctorRepository.Instance.GetDoctorbyId(appointment.Doctor.Jmbg);
        }
        public  List<Anamnesis> GetAllAnamnesisByDate(string patientId,DateTime startDate, DateTime finishDate)
        {
            var temp = new List<Anamnesis>();
            foreach (Anamnesis anamnesis in GetAllAnamnesisByPatientId(patientId))
            {
                if (anamnesis.AnamnesisDate >= startDate && anamnesis.AnamnesisDate <=finishDate)
                {
                    temp.Add(anamnesis);
                    BindDataForAppointment(anamnesis.Appointment);
                }
            }
            return temp;
        }
    }
}