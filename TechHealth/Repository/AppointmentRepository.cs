// File:    AppointmentRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:13:48 PM
// Purpose: Definition of Class AppointmentRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class AppointmentRepository : GenericRepository<string, Appointment>
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
      
      public List<Appointment> GetByDoctorId(string id)
      {
         List<Appointment> appointments = new List<Appointment>();
         foreach (var t in DictionaryValuesToList())
         {
            if (t.Doctor != null)
            {
               if (id.Equals(t.Doctor.Jmbg))
               {
                  appointments.Add(t);
               }
            }
         }

         return appointments;
      }
      
      public List<Appointment> GetByPatientId(string patientId)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var p in DictionaryValuesToList())
            {
                if (p.Patient != null)
                {
                    if (patientId.Equals(p.Patient.Jmbg))
                    {
                        appointments.Add(p);
                    }
                }
            }

            return appointments;
        }

        public List<Appointment> GetByRoomId(string roomId)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (var r in DictionaryValuesToList())
            {
                if (r.Room != null)
                {
                    if (roomId.Equals(r.Room.roomId))
                    {
                        appointments.Add(r);
                    }
                }
            }

            return appointments;
        }
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

      protected override void ShouldSerialize(Appointment entity)
      {
         entity.ShouldSerialize = true;

         entity.Patient.ShouldSerialize = false;
         entity.Doctor.ShouldSerialize = false;
         entity.Room.ShouldSerialize = false;

         //entity.Patient.ShouldSerialize = false;
         //entity.Doctor.ShouldSerialize = false;
         //entity.Room.ShouldSerialize = false;

      }
   }
}