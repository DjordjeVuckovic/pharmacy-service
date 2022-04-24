// File:    Person.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:44 AM
// Purpose: Definition of Class Person

using System;
using System.Text.Json.Serialization;
using PostSharp.Patterns.Model;

namespace TechHealth.Model
{
   [NotifyPropertyChanged]
   public class Person : User
   {
      public Address Address { get; set; }
      public string Name{ get; set; }
      public string Surname{ get; set; }
      public string Email{ get; set; }
      public string Jmbg{ get; set; }
      public string Phone{ get; set; }
      public bool Employed{ get; set; }
      public DateTime Birthday { get; set; }
      // [JsonIgnore]
      // public string FullName => $"{Name} {Surname}";
   }
}