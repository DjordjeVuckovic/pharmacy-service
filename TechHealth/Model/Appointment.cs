// File:    Appointment.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Appointment

using System;

namespace TechHealth.Model
{
   public class Appointment
   {
      private DateTime Date{ get; set; }
      private DateTime StartTime{ get; set; }
      private DateTime FinishTime{ get; set; }
      private string IdAppointment{ get; set; }
      
      public Room Room{ get; set; }
      public Patient Patient{ get; set; }
      public AppointmentType AppointmentType{ get; set; }
      public Doctor Doctor{ get; set; }
      
   
     
   
   }
}