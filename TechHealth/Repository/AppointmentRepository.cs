// File:    AppointmentRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class AppointmentRepository
   {
      private List<Appointment> appointments;
      
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
      
      public FileHandler fileHandler;
   
   }
}