// File:    ReferralRequest.cs
// Author:  djord
// Created: Monday, May 31, 2021 8:33:43 AM
// Purpose: Definition of Class ReferralRequest

using System;

namespace CaduceusHealth.Model
{
   public class ReferralRequest
   {
      private DateTime refferalDate;
      private String refferalId;
      
      public Patient patient;
      public Doctor doctor;
   
   }
}