// File:    AppointmentController.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentController

using System;

namespace CaduceusHealth.Controller
{
   public class AppointmentController
   {
      private AppointmentService appointmentService;
      private DoctorService doctorService;
      private PatientService patientService;
      
      public Appointment GetById(string idAppointment)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool Create(string doctorId, string patientId, DateTime date, DateTime startTime, DateTime finishTime, string roomId, AppointmentType type)
      {
         throw new NotImplementedException();
      }
      
      public bool Update(string doctorId, string patientId, DateTime date, DateTime startTime, DateTime finishTime, string roomId, AppointmentType type)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(string idAppointment)
      {
         throw new NotImplementedException();
      }
   
   }
}