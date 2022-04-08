// File:    PatientService.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class PatientService

using System;
using System.Collections.Generic;
using CaduceusHealth.Model;
using CaduceusHealth.Repository;

namespace CaduceusHealth.Service
{
   public class PatientService
   {
      private PatientRepository patientRepository;
      
      public Patient GetById(string patientId)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> GetAll()
      {
         throw new NotImplementedException();
      }
   
   }
}