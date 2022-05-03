// File:    DoctorService.cs
// Author:  djord
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class DoctorService

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
   public class DoctorService
   {

      public Doctor GetById(string doctorId)
      {
         return  DoctorRepository.Instance.GetDoctorbyId(doctorId);
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