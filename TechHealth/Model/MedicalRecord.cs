// File:    HealthRecord.cs
// Author:  djord
// Created: Monday, March 28, 2022 9:45:21 AM
// Purpose: Definition of Class HealthRecord

using System;
using System.Collections;
using System.Collections.Generic;

namespace TechHealth.Model
{
   public class MedicalRecord
   {
      public string recordId;
      
      public Bloodtype BloodType { get; set; }
      public Patient Patient { get; set; }
      
      //public IEnumerable<Allergen> Allergens { get; set; }
      public string Weight { get; set; }
      public string Height { get; set; }
      public string ChronicDiseases { get; set; }
      public string Allergens { get; set; }
      public string ParentDiseases { get; set; }
      private EmlpoymentData EmlpoymentData { get; set; }
   
   }
}