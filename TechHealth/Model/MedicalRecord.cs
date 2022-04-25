// File:    HealthRecord.cs
// Author:  djord
// Created: Monday, March 28, 2022 9:45:21 AM
// Purpose: Definition of Class HealthRecord

using System;
using System.Collections;
using System.Collections.Generic;
using TechHealth.Core;

namespace TechHealth.Model
{
   public class MedicalRecord:ViewModelBase
   {
      private string recordId;

      private Bloodtype bloodType;
      private Patient patient;
      
      //public IEnumerable<Allergen> Allergens { get; set; }
      private string weight;
      private string height;
      private string chronicDiseases;
      private string allergens;
      private string parentDiseases;
      private EmlpoymentData emlpoymentData;

      public string RecordId
      {
         get => recordId;
         set
         {
            recordId = value;
            OnPropertyChanged(nameof(RecordId));
         }
      }

      public Bloodtype BloodType{
         get => bloodType;
         set
         {
            bloodType = value;
            OnPropertyChanged(nameof(BloodType));
         }
      }
      public Patient Patient{
         get => patient;
         set
         {
            patient = value;
            OnPropertyChanged(nameof(Patient));
         }
      }
      
      //public IEnumerable<Allergen> Allergens { get; set; }
      public string Weight{
         get => weight;
         set
         {
            weight = value;
            OnPropertyChanged(nameof(Weight));
         }
      }
      public string Height{
         get => height;
         set
         {
            height = value;
            OnPropertyChanged(nameof(Height));
         }
      }
      public string ChronicDiseases{
         get => chronicDiseases;
         set
         {
            chronicDiseases = value;
            OnPropertyChanged(nameof(ChronicDiseases));
         }
      }
      public string Allergens{
         get => allergens;
         set
         {
            allergens = value;
            OnPropertyChanged(nameof(allergens));
         }
      }
      public string ParentDiseases{
         get => parentDiseases;
         set
         {
            parentDiseases = value;
            OnPropertyChanged(nameof(ParentDiseases));
         }
      }
      public EmlpoymentData EmlpoymentData{
         get => emlpoymentData;
         set
         {
            emlpoymentData = value;
            OnPropertyChanged(nameof(EmlpoymentData));
         }
      }
   
   }
}