// File:    Appointment.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Appointment

using System;
using Newtonsoft.Json;
using TechHealth.Core;

namespace TechHealth.Model
{
   
   public class Appointment:ViewModelBase
   {
      private DateTime date;
      private bool emergent;
      private string startTime;
      private string finishTime;
      private string idAppointment;
      private Room room;
      private Patient patient;
      private AppointmentType appointmentType;
      private Doctor doctor;
      private bool evident;
      private DateTime startTimeD;
      private DateTime finishTimeD;

      public Appointment(DateTime date, string idAppointment, Room room, Patient patient, AppointmentType appointmentType, Doctor doctor, DateTime startTimeD, DateTime finishTimeD)
      {
         this.date = date;
         emergent = false;
         this.idAppointment = idAppointment;
         this.room = room;
         this.patient = patient;
         this.appointmentType = appointmentType;
         this.doctor = doctor;
         this.evident = false;
         this.startTimeD = startTimeD;
         this.finishTimeD = finishTimeD;
         ShouldSerialize = true;
      }

      public Appointment()
      {
         
      }

      public bool ShouldSerialize { get; set; }
      

      public DateTime Date
      {
         get => date;
         set
         {
            date = value;
            OnPropertyChanged(nameof(Date));
         }
      }

      public DateTime StartTimeD
      {
         get => startTimeD;
         set
         {
            startTimeD = value;
            OnPropertyChanged(nameof(StartTimeD));
         } 
      }
      public DateTime FinishTimeD
      {
         get => finishTimeD;
         set
         {
            finishTimeD = value;
            OnPropertyChanged(nameof(FinishTimeD));
         } 
      }

      public bool Emergent
      {
         get => emergent;
         set
         {
            emergent = value;
            OnPropertyChanged(nameof(Emergent));
         }
      }

      public string StartTime
      {
         get => startTime;
         set
         {
            startTime = value;
            OnPropertyChanged(nameof(StartTime));
         }
      }

      public string FinishTime {
         get => finishTime;
         set
         {
            finishTime = value;
            OnPropertyChanged(nameof(FinishTime));
         }
      }
      public string IdAppointment{
         get => idAppointment;
         set
         {
            idAppointment = value;
            OnPropertyChanged(nameof(IdAppointment));
         }
      }
      public Room Room{
         get => room;
         set
         {
            room = value;
            OnPropertyChanged(nameof(Room));
         }
      }
      public Patient Patient{
         get => patient;
         set
         {
            patient = value;
            OnPropertyChanged(nameof(Patient));
         }
      }
      public AppointmentType AppointmentType{
         get => appointmentType;
         set
         {
            appointmentType = value;
            OnPropertyChanged(nameof(AppointmentType));
         }
      }
      public Doctor Doctor{
         get => doctor;
         set
         {
            doctor = value;
            OnPropertyChanged(nameof(Doctor));
         }
      }
      public bool Evident {
         get
         {
            return evident;
         }
         set
         {
            evident = value;
            OnPropertyChanged(nameof(Evident));
         }
      }
      public bool ShouldSerializeDate()
      {
         return ShouldSerialize;
      }

      public bool ShouldSerializeStartTimeD()
      {
         return ShouldSerialize;
      }
        
      public bool ShouldSerializeFinishTimeD()
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


      public bool DoctorConflicts(Appointment appointment)
      {
         if (appointment.Doctor.Jmbg != Doctor.Jmbg)
         {
            return false;
         }

         return appointment.Date == Date && appointment.StartTimeD < FinishTimeD && appointment.FinishTimeD > StartTimeD;
      }
      
   }
}