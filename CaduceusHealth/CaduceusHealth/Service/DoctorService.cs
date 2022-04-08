// File:    DoctorService.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class DoctorService

using System;
using System.Collections.Generic;
using CaduceusHealth.Model;
using CaduceusHealth.Repository;

namespace CaduceusHealth.Service
{
   public class DoctorService
   {
      private DoctorRepository doctorRepository;
      
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
   
   }
}