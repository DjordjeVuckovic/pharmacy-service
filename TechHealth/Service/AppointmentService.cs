// File:    AppointmentService.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using CaduceusHealth.Model;
using CaduceusHealth.Repository;

namespace CaduceusHealth.Service
{
   public class AppointmentService
   {
      private AppointmentRepository appointmentRepository;
      
      public Appointment GetById(string idAppointment)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool Create(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public bool Update(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(string idAppointment)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByDoctorId(string doctorId)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByPatientId(string patientId)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByRoomId(string roomId)
      {
         throw new NotImplementedException();
      }
   
   }
}