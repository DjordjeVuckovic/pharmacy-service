// File:    Person.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:44 AM
// Purpose: Definition of Class Person

using System;

namespace TechHealth.Model
{
   [Serializable]
   public class Person : User
   {
      public Address Address { get; set; }
      
      public void LogIn()
      {
         throw new NotImplementedException();
      }
      
      public string Name{ get; set; }
      public string Surname{ get; set; }
      public string Email{ get; set; }
      public string Jmbg{ get; set; }
      public string Phone{ get; set; }
      public bool Employed{ get; set; }
   
   }
}