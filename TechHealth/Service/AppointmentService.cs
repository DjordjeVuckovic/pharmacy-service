// File:    AppointmentService.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using TechHealth.Exceptions;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
   public class AppointmentService
   {
      
      private PatientService patientService = new PatientService();
      private DoctorService doctorService = new DoctorService();
      private RoomService roomService = new RoomService();
      public Appointment GetById(string idAppointment)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAll()
      {
         var temp = AppointmentRepository.Instance.GetAllToList();
         BindDataForAppointments(temp);
         return temp;
      }

      public bool Create(Appointment appointment)
      {
         CheckAvailability(appointment);
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
         var temp = AppointmentRepository.Instance.GetByDoctorId(doctorId);
         BindDataForAppointments(temp);
         return temp;
      }
      
      public List<Appointment> GetByPatientId(string patientId)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetByRoomId(string roomId)
      {
         throw new NotImplementedException();
      }

      private void BindDataForAppointments(List<Appointment> appointments)
      {
         foreach (var appointment in appointments)
         {
            appointment.Doctor = DoctorRepository.Instance.GetDoctorbyId(appointment.Doctor.Jmbg);
         }

         foreach (var appointment in appointments)
         {
            appointment.Patient = PatientRepository.Instance.GetById(appointment.Patient.Jmbg);
         }
         
      }

      private void CheckAvailability(Appointment appointment)
      {
         foreach (var existingAppointment in AppointmentRepository.Instance.GetAllToList())
         {
            if (existingAppointment.DoctorConflicts(appointment))
            {
               throw new AppointmentConflictException(existingAppointment,appointment);
            }
            
         }
         
      }
   
   }
}