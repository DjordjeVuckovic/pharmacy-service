// File:    Person.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:44 AM
// Purpose: Definition of Class Person

using System;
using Newtonsoft.Json;


namespace TechHealth.Model
{
   
   public class Person : User
   {
      private string surname;
      private string email;
      public Address Address { get; set; }

      public string Name { get; set; }

      public string Surname
      {
         get => surname;
         set => surname = value;
      }

      public string Email
      {
         get => email;
         set => email = value;
      }

      public string Jmbg{ get; set; }
      public string Phone{ get; set; }
      public bool Employed{ get; set; }
      public DateTime Birthday { get; set; }
      [JsonIgnore]
      public string FullName => $"{Name} {Surname}";
      public bool ShouldSerializeAddress()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeName()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeSurname()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeEmail()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializeEmployed()
      {
         return ShouldSerialize;
      }
      public bool ShouldSerializePhone()
      {
         return ShouldSerialize;
      }
     
      public bool ShouldSerializeBirthday()
      {
         return ShouldSerialize;
      }
   }
}