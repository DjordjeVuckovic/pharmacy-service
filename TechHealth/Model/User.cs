// File:    User.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:50:26 PM
// Purpose: Definition of Class User

using System;

namespace TechHealth.Model
{
   [Serializable]
   public class User
   {
      public string Username { get; set; }
      public string Password { get; set; }
   
   }
}