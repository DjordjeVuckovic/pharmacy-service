using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
    public class TherapyService
    {
        private AppointmentService appointmentService = new AppointmentService();
        public void Create(Therapy therapy)
        {
            TherapyRepository.Instance.Create(therapy);
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
            List<Therapy> therapies = GetAll();
            List<Therapy> ret = new List<Therapy>();
            foreach (var therapy in therapies)
            {
                if (therapy.Appointment != null)
                {
                    {
                        if (therapy.Appointment.Patient.Jmbg.Equals(patientId))
                        {
                            ret.Add(therapy);
                            BindDataForAppointment(therapy.Appointment);
                        }
                    }
                }

            }

            return ret;
        }
        private void BindDataForAppointment(Appointment appointment)
        {
            appointment.Doctor = DoctorRepository.Instance.GetDoctorbyId(appointment.Doctor.Jmbg);
            appointment.Room = RoomRepository.Instance.GetById(appointment.Room.roomId);
        }
    }
}