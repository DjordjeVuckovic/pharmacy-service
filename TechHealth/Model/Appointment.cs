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
      [JsonIgnore]
      public bool ShouldSerialize { get; set; }

      public DateTime Date
      {
         get
         {
            return date;
         }
         set
         {
            date = value;
            OnPropertyChanged(nameof(Date));
         }
      }

      public DateTime StartTimeD{ get; set; }
      public DateTime FinishTimeD{ get; set; }

      public bool Emergent
      {
         get
         {
            return emergent;
         }
         set
         {
            emergent = value;
            OnPropertyChanged(nameof(Emergent));
         }
      }

      public string StartTime
      {
         get
         {
            return startTime;
         }
         set
         {
            startTime = value;
            OnPropertyChanged(nameof(StartTime));
         }
      }

      public string FinishTime {
         get
         {
            return finishTime;
         }
         set
         {
            finishTime = value;
            OnPropertyChanged(nameof(FinishTime));
         }
      }
      public string IdAppointment{
         get
         {
            return idAppointment;
         }
         set
         {
            idAppointment = value;
            OnPropertyChanged(nameof(IdAppointment));
         }
      }
      public Room Room{
         get
         {
            return room;
         }
         set
         {
            room = value;
            OnPropertyChanged(nameof(Room));
         }
      }
      public Patient Patient{
         get
         {
            return patient;
         }
         set
         {
            patient = value;
            OnPropertyChanged(nameof(Patient));
         }
      }
      public AppointmentType AppointmentType{
         get
         {
            return appointmentType;
         }
         set
         {
            appointmentType = value;
            OnPropertyChanged(nameof(AppointmentType));
         }
      }
      public Doctor Doctor{
         get
         {
            return doctor;
         }
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
      
      
      

     

      
      
      
      
     
   
   }
}