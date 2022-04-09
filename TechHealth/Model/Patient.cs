// File:    Patient.cs
// Author:  djord
// Created: Monday, March 28, 2022 9:32:21 AM
// Purpose: Definition of Class Patient

using System;

namespace TechHealth.Model
{
   public class Patient : Person
   {
      public bool guest;
      public Doctor chosenDoctor;
      public int lbo;
      public bool isBanned;
   
   }
}