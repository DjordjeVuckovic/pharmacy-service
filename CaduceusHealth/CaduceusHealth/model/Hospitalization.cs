// File:    Hospitalization.cs
// Author:  djord
// Created: Monday, May 31, 2021 11:36:19 AM
// Purpose: Definition of Class Hospitalization

using System;

namespace CaduceusHealth.Model
{
   public class Hospitalization
   {
      private DateTime startDate;
      private DateTime finishDate;
      private String hospitalizationId;
      
      public Specialist specialist;
      public Patient patient;
      public Room room;
   
   }
}