// File:    Patient.cs
// Author:  djord
// Created: Monday, March 28, 2022 9:32:21 AM
// Purpose: Definition of Class Patient

namespace TechHealth.Model
{

    public class Patient : Person
    {
        public bool Guest { get; set; }
        public Doctor ChosenDoctor { get; set; }
        public int Lbo { get; set; }
        public bool IsBanned { get; set; }
        public bool ShouldSerializeGuest()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeChosenDoctor()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeIsBanned()
        {
            return ShouldSerialize;
        }



    }
}