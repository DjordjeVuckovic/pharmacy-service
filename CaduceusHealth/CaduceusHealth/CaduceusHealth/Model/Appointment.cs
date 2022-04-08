// File:    Appointment.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Appointment

using System;

namespace CaduceusHealth.Model
{
   public class Appointment
   {
      private DateTime date;
      private DateTime startTime;
      private DateTime finishTime;
      private string idAppointment;
      
      public Room room;
      public Patient patient;
      public AppointmentType appointmentType;
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