// File:    Specialization.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:09:31 PM
// Purpose: Definition of Class Specialization

using System;
using TechHealth.Core;

namespace TechHealth.Model
{
   public class Specialization:ViewModelBase
   {
      private int idSpecialization;

      public int IdSpecialization
      {
         get => idSpecialization;
         set
         { 
            idSpecialization = value;
            OnPropertyChanged(nameof(IdSpecialization));
         }
      }

      public string NameSpecialization{ get; set; }
      
   }
}