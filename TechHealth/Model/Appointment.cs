// File:    Appointment.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Appointment

using System;
using Newtonsoft.Json;
using TechHealth.Core;

namespace TechHealth.Model
{
   
   public class Appointment
   {
      private DateTime date;
      private bool emergent;
      private string idAppointment;
      private Room room;
      private Patient patient;
      private AppointmentType appointmentType;
      private Doctor doctor;
      private bool evident;
      private DateTime startTime;
      private DateTime finishTime;

      public Appointment(DateTime date, string idAppointment, Room room, Patient patient, AppointmentType appointmentType, Doctor doctor,
          DateTime startTime, DateTime finishTime)
      {
         this.date = date;
         emergent = false;
         this.idAppointment = idAppointment;
         this.room = room;
         this.patient = patient;
         this.appointmentType = appointmentType;
         this.doctor = doctor;
         this.evident = false;
         this.startTime = startTime;
         this.finishTime = finishTime;
         ShouldSerialize = true;
      }

      public Appointment()
      {
         
      }

      public bool ShouldSerialize { get; set; }
      

      public DateTime Date
      {
         get => date;
         set => date = value;
      }

      public DateTime StartTime
      {
         get => startTime;
         set => startTime = value;
      }
      public DateTime FinishTime
      {
         get => finishTime;
         set => finishTime = value;
      }

      public bool Emergent
      {
         get => emergent;
         set => emergent = value;
      }

      public string IdAppointment{
         get => idAppointment;
         set => idAppointment = value;
      }
        public Room Room{
         get => room;
         set => room = value;
        }
      public Patient Patient{
         get => patient;
         set => patient = value;
      }
      public AppointmentType AppointmentType{
         get => appointmentType;
         set => appointmentType = value;
      }
      public Doctor Doctor{
         get => doctor;
         set => doctor = value;
      }
      public bool Evident {
         get => evident;
         set => evident = value;
      }
        public bool ShouldSerializeDate()
      {
         return ShouldSerialize;
      }
      

      public bool ShouldSerializeAppointmentType()
      {
         return ShouldSerialize;
      }

      public bool ShouldSerializeDoctor()
      {
         return ShouldSerialize;
      }

      public bool ShouldSerializePatient()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeRoom()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeEvident()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeStartTime()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeFinishTime()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeEmergent()
      {
         return ShouldSerialize;
      }


      public bool DoctorConflicts(Appointment appointment)
      {
         if (appointment.Doctor.Jmbg != Doctor.Jmbg)
         {
            return false;
         }

         return appointment.Date == Date && appointment.StartTime < FinishTime && appointment.FinishTime > StartTime;
      }
      public bool RoomConflicts(Appointment appointment)
      {
         if (appointment.Room.RoomId != Room.RoomId)
         {
            return false;
         }

         return appointment.Date == Date && appointment.StartTime < FinishTime && appointment.FinishTime > StartTime;
      }
      public bool PatientConflicts(Appointment appointment)
      {
         if (appointment.Patient.Jmbg != Patient.Jmbg)
         {
            return false;
         }

         return appointment.Date == Date && appointment.StartTime < FinishTime && appointment.FinishTime > StartTime;
      }

        public bool GetIfPast()
        {
            return FinishTime < DateTime.Now;
        }

    }
}