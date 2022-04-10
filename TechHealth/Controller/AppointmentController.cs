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
      private AppointmentService appointmentService;
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