
using System;
using System.Text.Json.Serialization;
using PostSharp.Patterns.Model;

namespace TechHealth.Model
{
   [NotifyPropertyChanged] 
   public class Doctor : Person
   {
      public Specialization Specialization{ get; set; }
      [JsonIgnore]
      public string FullSpecialization => $"{Name} {Surname} - {Specialization.NameSpecialization} ";
      public string FullName => $"{Name} {Surname}";
    }
}