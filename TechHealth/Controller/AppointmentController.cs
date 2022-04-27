// File:    AppointmentController.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentController

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Service;

namespace TechHealth.Controller
{
   public class AppointmentController
   {
      private static AppointmentController _instance;
      private readonly AppointmentService appointmentService = new AppointmentService();
      private DoctorService doctorService;
      private PatientService patientService;

      public static AppointmentController Instance => _instance;
      
      public Appointment GetById(string idAppointment)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAll()
      {
         return appointmentService.GetAll();
      }
      
      public bool Create(string doctorId, string patientId, DateTime date, DateTime startTime, DateTime finishTime, string roomId, AppointmentType type)
      {
            throw new NotImplementedException();
        }

      public void Create(Appointment appointment)
      {
          appointmentService.CreateA(appointment);
      }

      public bool Create(DateTime date, string startTime, AppointmentType appointmentType, Doctor doctor, string idApointment)
      {
            var appointment = new Appointment();
            appointment.Date = date;
            appointment.StartTime = startTime;
            appointment.AppointmentType = appointmentType;
            appointment.Doctor = doctor;
            appointment.IdAppointment = idApointment;

            return appointmentService.Create(appointment);
        }

        public bool Update(string doctorId, string patientId, DateTime date, DateTime startTime, DateTime finishTime, string roomId, AppointmentType type)
        {
            throw new NotImplementedException();
        }

        public bool Update(DateTime date, string startTime, AppointmentType appointmentType, Doctor doctor, string idApointment)
        {
            var appointment = new Appointment();
            appointment.Date = date;
            appointment.StartTime = startTime;
            appointment.AppointmentType = appointmentType;
            appointment.Doctor = doctor;
            appointment.IdAppointment = idApointment;

            return appointmentService.Create(appointment);
        }

        public bool Delete(string idAppointment)
      {
            return appointmentService.Delete(idAppointment);
      }

    
    }
}