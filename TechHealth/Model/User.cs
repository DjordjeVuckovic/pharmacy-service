// File:    User.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:50:26 PM
// Purpose: Definition of Class User

using System;
using TechHealth.Core;

namespace TechHealth.Model
{
   
   public class User:ViewModelBase
   {
      private string password;
      private string username;

      public string Username
      {
         get => username;
         set
         {
            username = value;
            OnPropertyChanged(nameof(Username));
         }
      }


      public string Password
      {
         get => password;
         set
         {
            password = value; 
            OnPropertyChanged(nameof(Password));
         }
      }
   }
}