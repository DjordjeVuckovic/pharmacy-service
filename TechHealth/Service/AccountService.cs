// File:    AccountService.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountService

using System;
using System.Collections.Generic;
using TechHealth.Model;
using TechHealth.Repository;

namespace TechHealth.Service
{
   public class AccountService
   {
      private AccountRepository accountRepository;
      
      public User GetByUsername(string username)
      {
            return accountRepository.GetByUsername(username);
      }
      
      public List<User> GetAll()
      {
            return accountRepository.GetAll();
      }
      
      public bool Create(Person person)
      {
            return accountRepository.Create(person);
      }
      
      public bool Update(Person person)
      {
         return accountRepository.Update(person);
      }
      
      public bool Delete(string username)
      {
            return accountRepository.Delete(username);
      }
      
      public bool CreateGuest(User user)
      {
            return accountRepository.CreateGuest(user);
      }
      
      public bool DeleteGuest(string userId)
      {
            return accountRepository.DeleteGuest(userId);
      }
      
      public bool UpdateGuest(User user)
      {
            return accountRepository.UpdateGuest(user);
      }
   
   }
}