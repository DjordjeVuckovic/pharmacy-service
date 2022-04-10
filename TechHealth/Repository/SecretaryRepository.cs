// File:    SecretaryRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:18:02 PM
// Purpose: Definition of Class SecretaryRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class SecretaryRepository:GenericRepository<string,Secretary>
   {
      private static readonly SecretaryRepository instance = new SecretaryRepository();

      // Explicit static constructor to tell C# compiler
      // not to mark type as beforefieldinit
      static SecretaryRepository()
      {
      }

      private SecretaryRepository()
      {
      }

      public static SecretaryRepository Instance => instance;
      protected override string GetPath()
      {
         return @"../../Json/secretary.json";
      }

      protected override string GetKey(Secretary entity)
      {
         return entity.Jmbg;
      }

      protected override void RemoveAllReference(string key)
      {
         throw new NotImplementedException();
      }
      
   }
}