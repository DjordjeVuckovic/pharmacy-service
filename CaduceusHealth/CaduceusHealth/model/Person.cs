// File:    Person.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:44 AM
// Purpose: Definition of Class Person

using System;

namespace CaduceusHealth.Model
{
   public class Person : User
   {
      private string name;
      private string surname;
      private int email;
      private string jmbg;
      private string phone;
      private bool employed;
      
      private Address address;
      
      public void LogIn()
      {
         throw new NotImplementedException();
      }
   
   }
}