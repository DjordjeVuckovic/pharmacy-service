// File:    AccountController.cs
// Author:  nsred
// Created: Thursday, April 7, 2022 6:16:56 PM
// Purpose: Definition of Class AccountController

using System;
using System.Collections.Generic;
using CaduceusHealth.Model;
using CaduceusHealth.Service;

namespace CaduceusHealth.Controller
{
   public class AccountController
   {
      private AccountService accountService;
      
      public User GetByUsername(string username)
      {
         throw new NotImplementedException();
      }
      
      public List<User> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public bool Create(string username, string password, string jmbg, string phone, string email, bool employed)
      {
         throw new NotImplementedException();
      }
      
      public bool Update(string username, string password, string jmbg, string phone, string email, bool employed)
      {
         throw new NotImplementedException();
      }
      
      public bool Delete(string personId)
      {
         throw new NotImplementedException();
      }
      
      public bool CreateGuest(string userId, string password)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteGuest(string userId)
      {
         throw new NotImplementedException();
      }
      
      public int UpdateGuest(string userId, string password)
      {
         throw new NotImplementedException();
      }
   
   }
}