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
      private string weight;
      private string height;
      private string chronicDiseases;
      private string parentDiseases;
      private string martialStatus;
      private EmlpoymentData emlpoymentData;

        public bool ShouldSerialize { get; set; }

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

      public string MartialStatus
      {
         get => martialStatus;
         set
         {
            martialStatus = value;
            OnPropertyChanged(nameof(MartialStatus));
         }
      }
      public Gender Gender { get; set; }

      public string GenderToString()
      {
         string ret="";
         switch (Gender)
         {
            case Gender.Female:
               ret= "Female";
               break;
            case Gender.Male:
               ret= "Male";
               break;
            case Gender.None:
               ret= "None";
               break;
            
         }
         return ret;
      }
      public String BloodTypeToString()
      {
         string ret="";
         switch (BloodType)
         {
            case Bloodtype.An:
               ret = "A-";
               break;
            case Bloodtype.Ap:
               ret = "A+";
               break;
            case Bloodtype.ABn:
               ret = "AB-";
               break;
            case Bloodtype.ABp:
               ret = "AB+";
               break;
            case Bloodtype.Bn:
               ret = "B-";
               break;
            case Bloodtype.Bp:
               ret = "B+";
               break;
            case Bloodtype.On:
               ret = "0-";
               break;
            case Bloodtype.Op:
               ret = "0+";
               break;
            case Bloodtype.None:
               ret = "";
               break;

         }

         return ret;

      }
   
   }
}