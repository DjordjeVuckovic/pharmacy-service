// File:    PatientRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class PatientRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class PatientRepository:GenericRepository<string,Patient>
   {
      private static readonly PatientRepository instance = new PatientRepository();

      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static PatientRepository()
      {
      }

      private PatientRepository()
      {
      }

      public static PatientRepository Instance => instance;

      protected override string GetPath()
      {
         return @"../../Json/patient.json";
      }

      protected override string GetKey(Patient entity)
      {
         return entity.Jmbg;
      }

      protected override void RemoveAllReference(string key)
      {
         throw new NotImplementedException();
      }

      protected override void ShouldSerialize(Patient entity)
      {
         throw new NotImplementedException();
      }

      public Patient GetPatientbyId(string patientId)
      {
         throw new NotImplementedException();
      }
   }
}