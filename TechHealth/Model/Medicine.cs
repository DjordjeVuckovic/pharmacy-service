// File:    Medicine.cs
// Author:  djord
// Created: Monday, March 28, 2022 10:08:11 AM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;

namespace TechHealth.Model
{
    public class Medicine
    {
        public string MedicineId{ get; set; }
        public List<Substance> Composition{ get; set; }
        public int Quantity{ get; set; }
        public string Units{ get; set; }
        public string SideEffects{ get; set; }
        public Substance MainSubstance{ get; set; }
        public int HarmfulRate { get; set; }
        public double Price{ get; set; }
        public string MedicineName{ get; set; }
        public string Allergens { get; set; }
        //public IEnumerable<Allergen> allergens;
        public bool Approved { get; set; }
    }

}