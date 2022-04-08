// File:    DoctorRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class DoctorRepository

using System;
using System.Collections.Generic;
using CaduceusHealth.Model;

namespace CaduceusHealth.Repository
{
   public class DoctorRepository
   {
      private List<Doctor> doctors;
      
      public Doctor GetById(string doctorId)
      {
         throw new NotImplementedException();
      }
      
      public List<Doctor> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public List<Doctor> GetAllGeneral()
      {
         throw new NotImplementedException();
      }
      
      public List<Doctor> GetAllSpecialist()
      {
         throw new NotImplementedException();
      }
      
      public FileHandler fileHandler;
   
   }
}