// File:    Appointment.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Appointment

using System;
using PostSharp.Patterns.Model;
using Scar.Common.WPF.Controls;

namespace TechHealth.Model
{
   [NotifyPropertyChanged]
   public class Appointment
   {
      public DateTime Date{ get; set; }
      public DateTime StartTimeD{ get; set; }
      public DateTime FinishTimeD{ get; set; }
      public string StartTime{ get; set; }
      public string FinishTime{ get; set; }
      public string IdAppointment{ get; set; }
      public bool Emergent { get; set; }
      
      
      public Room Room{ get; set; }
      public Patient Patient{ get; set; }
      public AppointmentType AppointmentType{ get; set; }
      public Doctor Doctor{ get; set; }
      
      
     
   
   }
}