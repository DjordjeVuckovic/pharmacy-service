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
   public class MedicalRecord
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
         }
      }

      public Bloodtype BloodType{
         get => bloodType;
         set
         {
            bloodType = value;
         }
      }
      public Patient Patient{
         get => patient;
         set
         {
            patient = value;
         }
      }
      public string Weight{
         get => weight;
         set
         {
            weight = value;
         }
      }
      public string Height{
         get => height;
         set
         {
            height = value;
         }
      }
      public string ChronicDiseases{
         get => chronicDiseases;
         set
         {
            chronicDiseases = value;
         }
      }
      public string ParentDiseases{
         get => parentDiseases;
         set
         {
            parentDiseases = value;
         }
      }
      public EmlpoymentData EmlpoymentData{
         get => emlpoymentData;
         set
         {
            emlpoymentData = value;
         }
      }

      public string MartialStatus
      {
         get => martialStatus;
         set
         {
            martialStatus = value;
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