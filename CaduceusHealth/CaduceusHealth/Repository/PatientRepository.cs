// File:    PatientRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class PatientRepository

using System;
using System.Collections.Generic;
using CaduceusHealth.Model;

namespace CaduceusHealth.Repository
{
   public class PatientRepository
   {
      private List<Patient> patients;
      
      public Patient GetById(string patientId)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public FileHandler fileHandler;
   
   }
}