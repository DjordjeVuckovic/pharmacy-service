// File:    Note.cs
// Author:  djord
// Created: Saturday, April 2, 2022 10:03:54 PM
// Purpose: Definition of Class Note

using System;
using System.Windows.Controls;

namespace TechHealth.Model
{
   public class Note
   {

        public string NoteId { get; set; }
        public string Label { get; set; }
        public string Content { get; set; }
        //public DateTime NotificationTime { get; set; }
        public bool Checked { get; set; }
        public Appointment SelectedAppointment { get; set; }
        public Patient Patient { get; set; }
        public DateTime RemindDate { get; set; }
        public DateTime RemindTime { get; set; }
    }
}