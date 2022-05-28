using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
   public class AppointmentController
   {
      
      private readonly AppointmentService appointmentService = new AppointmentService();
      private readonly  DoctorService doctorService = new DoctorService();
      private readonly  PatientService patientService = new PatientService();

        public void Postpone(Appointment appointment)
        {
            appointmentService.Postpone(appointment);
        }
        public Appointment GetById(string idAppointment)
        {
          return appointmentService.GetById(idAppointment);
        }
      
      public ObservableCollection<Appointment> GetAll()
      {
         return new ObservableCollection<Appointment>(appointmentService.GetAll());
      }
      
      public bool Create(string doctorId, string patientId, DateTime date, DateTime startTime, DateTime finishTime, string roomId, AppointmentType type)
      {
            throw new NotImplementedException();
        }

      public void Create(Appointment appointment)
      {
          appointmentService.Create(appointment);
      }

      

        public bool Update(string doctorId, string patientId, DateTime date, DateTime startTime, DateTime finishTime, string roomId, AppointmentType type)
        {
            throw new NotImplementedException();
        }
       

        public void Update(Appointment appointment)
        {
            appointmentService.Update(appointment);
        }

        public bool Delete(string idAppointment)
        {
            return appointmentService.Delete(idAppointment);
        }
        public ObservableCollection<Appointment> GetByDoctorId(string doctorId)
        {

            return new ObservableCollection<Appointment>(appointmentService.GetByDoctorId(doctorId));
        }
        public ObservableCollection<Appointment> GetAllNotEvidentByDoctorId(string doctorId)
        {
            return new ObservableCollection<Appointment>(appointmentService.GetAllNotEvidentByDoctorId(doctorId));
        }

        public List<Appointment> GetAllNotEvident()
        {
            return appointmentService.GetAllNotEvident();
        }

        public List<Appointment> GetAllEvident()
        {
            return appointmentService.GetAllEvident();
        }





    }
}