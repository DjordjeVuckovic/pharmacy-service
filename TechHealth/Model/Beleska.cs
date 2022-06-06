// File:    Note.cs
// Author:  djord
// Created: Saturday, April 2, 2022 10:03:54 PM
// Purpose: Definition of Class Note

using System;

namespace TechHealth.Model
{
   public class Beleska
   {
      public string noteId;
        public string naslov;
      public string content;
        public DateTime notificationTime;
        public bool Checked { get; set; }
        public Appointment selectedAppointment;
        public Patient patient;




    }
}