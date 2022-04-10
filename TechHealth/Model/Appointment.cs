// File:    Appointment.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Appointment

using System;
using PostSharp.Patterns.Model;

namespace TechHealth.Model
{
   [NotifyPropertyChanged]
   public class Appointment
   {
      public DateTime Date{ get; set; }
      public DateTime StartTime{ get; set; }
      public DateTime FinishTime{ get; set; }
      public string IdAppointment{ get; set; }
      public bool Emergent { get; set; }
      
      public Room Room{ get; set; }
      public Patient Patient{ get; set; }
      public AppointmentType AppointmentType{ get; set; }
      public Doctor Doctor{ get; set; }
      
   
     
   
   }
}