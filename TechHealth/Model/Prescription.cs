// File:    Prescription.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:36:28 PM
// Purpose: Definition of Class Prescription

using System;

namespace TechHealth.Model
{
   public class Prescription
   {
      public string PrescriptionId { get; set; }
      public Medicine Medicine{ get; set; }
      public string Quantity{ get; set; }
      public string SideEffects{ get; set; }
      public string Usage{ get; set; }
      public DateTime PrescriptionDate { get; set; } 
      
      public Doctor Doctor{ get; set; }
      public Patient Patient{ get; set; }
   
   }
}