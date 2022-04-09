// File:    Specialist.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:08:47 PM
// Purpose: Definition of Class Specialist

using System;

namespace TechHealth.Model
{
   public class Specialist : Doctor
   {
      public Specialization Specialization{ get; set; }
   
   }
}