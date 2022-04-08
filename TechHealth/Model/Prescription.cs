// File:    Prescription.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:36:28 PM
// Purpose: Definition of Class Prescription

using System;

namespace CaduceusHealth.Model
{
   public class Prescription
   {
      private string medicineId;
      private string medicineName;
      private string patientLbo;
      private int quantity;
      private string sideEffects;
      private string diganosis;
      
      public Doctor doctor;
      public Patient patient;
   
   }
}