// File:    ReferralRequest.cs
// Author:  djord
// Created: Monday, May 31, 2021 8:33:43 AM
// Purpose: Definition of Class ReferralRequest

using System;

namespace TechHealth.Model
{
   public class ReferralRequest
   {
      public DateTime refferalDate;
      public String refferalId;
      
      public Patient patient;
      public Doctor doctor;
   
   }
}