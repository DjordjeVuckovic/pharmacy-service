// File:    AppointmentService.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
   public class AppointmentService
   {
      
      public Appointment GetById(string idAppointment)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAll()
      {
        return AppointmentRepository.Instance.DictionaryValuesToList();
      }

      public bool Create(Appointment appointment)
      {
            return AppointmentRepository.Instance.Create(appointment);
      }
      
      public bool Update(Appointment appointment)
      {
            return AppointmentRepository.Instance.Update(appointment);
        }
      
      public bool Delete(string idAppointment)
      {
            return AppointmentRepository.Instance.Delete(idAppointment);
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