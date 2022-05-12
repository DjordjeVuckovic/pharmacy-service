// File:    ReferralRequest.cs
// Author:  djord
// Created: Monday, May 31, 2021 8:33:43 AM
// Purpose: Definition of Class ReferralRequest

using System;

namespace TechHealth.Model
{
   public class ReferralRequest
   {
      public String ReferralId { get; set; }
      
      public Appointment Appointment { get; set; }
      public Doctor ReferralDoctor { get; set; }
      public DateTime Date { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime FinishTime { get; set; }

   }
}