// File:    Patient.cs
// Author:  djord
// Created: Monday, March 28, 2022 9:32:21 AM
// Purpose: Definition of Class Patient

using System;

namespace CaduceusHealth.Model
{
   public class Patient : Person
   {
      private bool guest;
      private Doctor chosenDoctor;
      private int lbo;
      private bool isBanned;
   
   }
}