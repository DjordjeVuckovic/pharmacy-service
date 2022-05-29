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

      public void Create(Appointment appointment)
      {
          appointmentService.Create(appointment);
      }

      public void Update(Appointment appointment)
        {
            appointmentService.Update(appointment);
        }

        public bool Delete(string idAppointment)
        {
            return appointmentService.Delete(idAppointment);
        }
        public List<Appointment> GetByDoctorId(string doctorId)
        {

            return appointmentService.GetByDoctorId(doctorId);
        }
        public List<Appointment> GetAllNotEvidentByDoctorId(string doctorId)
        {
            return appointmentService.GetAllNotEvidentByDoctorId(doctorId);
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