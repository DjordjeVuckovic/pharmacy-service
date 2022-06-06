using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;
using TechHealth.Service.IService;

namespace TechHealth.Service
{
    public class TherapyService:ITherapyService
    {
        public bool Create(Therapy therapy)
        {
            return TherapyRepository.Instance.Create(therapy);
        }

        public bool Update(Therapy entity)
        {
            throw new System.NotImplementedException();
        }

        public Therapy GetById(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public List<Therapy> GetAll()
        {
            var temp = TherapyRepository.Instance.GetAllToList();
            BindDataForTherapy(temp);
            return temp;
        }

        private void BindDataForTherapy(List<Therapy> therapies)
        {
            foreach (var therapy in therapies)
            {
                therapy.Appointment = AppointmentRepository.Instance.GetById(therapy.Appointment.IdAppointment);
            }
        }

        public List<Therapy> GetAllByPatientId(string patientId)
        {
            List<Therapy> ret = new List<Therapy>();
            foreach (var therapy in GetAll())
            {
                if (therapy.Appointment != null && therapy.Appointment.Patient.Jmbg.Equals(patientId))
                {
                    ret.Add(therapy);
                    BindDataForAppointment(therapy.Appointment);
                }
            }

            return ret;
        }
        private void BindDataForAppointment(Appointment appointment)
        {
            appointment.Doctor = DoctorRepository.Instance.GetDoctorbyId(appointment.Doctor.Jmbg);
            appointment.Room = RoomRepository.Instance.GetById(appointment.Room.RoomId);
        }
    }
}