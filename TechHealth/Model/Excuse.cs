// File:    Excuse.cs
// Author:  djord
// Created: Saturday, April 2, 2022 9:48:02 PM
// Purpose: Definition of Class Excuse

using System;

namespace CaduceusHealth.Model
{
   public class Excuse
   {
      private int idExcuse;
      private DateTime startDate;
      private DateTime finishDate;
      
      public Patient patient;
      public Doctor doctor;
      
      /// <summary>
      /// Property for Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Doctor Doctor
      {
         get
         {
            return doctor;
         }
         set
         {
            this.doctor = value;
         }
      }
   
   }
}