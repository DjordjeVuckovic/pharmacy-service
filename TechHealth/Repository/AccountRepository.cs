// File:    AccountRepository.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountRepository

using System;
using System.Collections.Generic;
using TechHealth.Model;

namespace TechHealth.Repository
{
   public class AccountRepository
   {
      private List<User> users;
      
      public User GetByUsername(string username)
      {
         throw new NotImplementedException();
      }
      
      public List<User> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool Create(Person person)
      {
         throw new NotImplementedException();
      }
      
      public bool Update(Person person)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(string username)
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
      
      public FileHandler fileHandler;
   
   }
}