// File:    Hospitalization.cs
// Author:  djord
// Created: Monday, May 31, 2021 11:36:19 AM
// Purpose: Definition of Class Hospitalization

using System;

namespace TechHealth.Model
{
    public class Hospitalization
    {
        public DateTime startDate;
        public DateTime finishDate;
        public String hospitalizationId;

        public Specialist specialist;
        public Patient patient;
        public Room room;

    }
}