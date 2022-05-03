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

      protected override void ShouldSerialize(Doctor entity)
      {
         throw new NotImplementedException();
      }

      public Doctor GetDoctorByUser(string user)
      {
         foreach (var doc in GetAllToList())
         {
            if (doc.Username.Equals(user))
            {
               return doc;
            }
         }

         return null;
      }

      public Doctor GetDoctorbyId(string id)
      {
         foreach (var doc in GetAllToList())
         {
            if (doc.Jmbg.Equals(id))
            {
               return doc;
            }
         }

         return null;
      }
   
   }
}