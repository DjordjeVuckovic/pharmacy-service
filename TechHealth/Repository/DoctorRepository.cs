// File:    DoctorRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class DoctorRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class DoctorRepository:GenericRepository<string,Doctor>
   {
      private static readonly DoctorRepository instance = new DoctorRepository();

      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static DoctorRepository()
      {
      }

      private DoctorRepository()
      {
      }

      public static DoctorRepository Instance => instance;

      public Doctor GetById(string doctorId)
      {
         throw new NotImplementedException();
      }

        protected override string GetPath()
        {
            return @"../../Json/doctor.json";
        }

      protected override string GetKey(Doctor entity)
      {
         return entity.Jmbg;
      }

      protected override void RemoveAllReference(string key)
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