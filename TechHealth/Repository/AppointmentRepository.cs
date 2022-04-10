// File:    AppointmentRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class AppointmentRepository:GenericRepository<string,Appointment>
   {
      private static readonly AppointmentRepository instance = new AppointmentRepository();

      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static AppointmentRepository()
      {
      }

      private AppointmentRepository()
      {
      }
      public static AppointmentRepository Instance => instance;
      
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

      protected override string GetPath()
      {
         return @"../../Json/appointment.json";
      }

      protected override string GetKey(Appointment entity)
      {
         return entity.IdAppointment;
      }

      protected override void RemoveAllReference(string key)
      {
         throw new NotImplementedException();
      }
   }
}