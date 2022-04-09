// File:    Person.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:44 AM
// Purpose: Definition of Class Person

using System;

namespace TechHealth.Model
{
   public class Person : User
   {
      private Address address;
      
      public void LogIn()
      {
         throw new NotImplementedException();
      }
      
      public string name;
      public string surname;
      public int email;
      public string jmbg;
      public string phone;
      public bool employed;
   
   }
}