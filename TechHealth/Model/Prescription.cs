// File:    Prescription.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:36:28 PM
// Purpose: Definition of Class Prescription

using System;

namespace TechHealth.Model
{
   public class Prescription
   {
      public string medicineId;
      public string medicineName;
      public string patientLbo;
      public int quantity;
      public string sideEffects;
      public string diganosis;
      
      public Doctor doctor;
      public Patient patient;
   
   }
}