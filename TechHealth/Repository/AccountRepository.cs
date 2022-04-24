// File:    AccountRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountRepository

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using System.Windows.Documents;
using TechHealth.Model;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TechHealth.Repository
{
   public class AccountRepository:GenericRepository<string,Person>
   {
        private static readonly AccountRepository instance = new AccountRepository();

        static AccountRepository()
        { 
        }

        private AccountRepository()
        { 
        }

        public static AccountRepository Instance => instance;

        public User GetByUsername(string username)
      {
         throw new NotImplementedException();
      }
      
      protected override string GetPath()
      {
            return @"../../Json/account.json";
        }

      protected override string GetKey(Person entity)
      {
            return entity.Jmbg;
      }

      protected override void RemoveAllReference(string key)
      {
         throw new NotImplementedException();
      }
      
      
      public bool CreateGuest(User user)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteGuest(string userId)
      {
         throw new NotImplementedException();
      }
      
      public int UpdateGuest(User user)
      {
         throw new NotImplementedException();
      }
      
   
   }
}