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
         foreach (var t in GetAllToList())
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
            foreach (var p in GetAllToList())
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
            foreach (var r in GetAllToList())
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

        public bool CanSetRenovation(DateTime start, DateTime end, string roomID)
        {
            if (GetAllToList().Count != 0)
            {
                foreach (var app in GetAllToList())
                {
                    if(((start >= app.StartTime && start <= app.FinishTime) || (end >= app.StartTime && end <= app.FinishTime)
                        || (start <= app.StartTime && end >= app.FinishTime)) && app.Room.roomId == roomID)
                    {
                        return false;
                    }
                }
                return true;
            }
            else return true;
        }

        public bool CanDoReallocation(DateTime date, string src, string dst)
        {
            if (GetAllToList().Count != 0)
            {
                foreach (var app in GetAllToList())
                {
                    if ((app.Room.roomId == src || app.Room.roomId == dst) && (date >= app.StartTime && date <= app.FinishTime))
                    {
                        return false;
                    }
                }
                return true;
            }
            else return true;
        }
        public bool CanPostpone(Appointment appointment)
        {
            if (GetAllToList().Count != 0)
            {
                foreach (var app in GetAllToList())
                {
                    if ((appointment.Doctor.Jmbg.Equals(app.Doctor.Jmbg)) && (appointment.Date.Equals(app.Date)))
                    {
                        if (DateTime.Compare(DateTime.Parse(appointment.StartTime.ToString("HH:mm")), DateTime.Parse(app.StartTime.ToString("HH:mm"))) >= 0)
                        {
                            if (DateTime.Compare(DateTime.Parse(appointment.StartTime.ToString("HH:mm")), DateTime.Parse(app.FinishTime.ToString("HH:mm"))) <= 0)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else return true;
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

        }
   }
}