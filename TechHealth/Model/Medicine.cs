// File:    Medicine.cs
// Author:  djord
// Created: Monday, March 28, 2022 10:08:11 AM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TechHealth.Model
{
    public class Medicine
    {
        public string MedicineId{ get; set; }
        public List<Substance> Composition{ get; set; }
        public int Quantity{ get; set; }
        public string Units{ get; set; }
        public string SideEffects{ get; set; }
        public Substance MainSubstance { get; set; }
        public double Price{ get; set; }
        public string MedicineName{ get; set; }
        //public IEnumerable<Allergen> allergens;
        public bool Approved { get; set; }
        public bool ShouldSerialize { get; set; }
        public bool ShouldSerializeComposition()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeQuantity()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeUnits()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeSideEffects()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeMainSubstance()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeHarmfulRate()
        {
            return ShouldSerialize;
            
        }
        public bool ShouldSerializePrice()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeAllergens()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeApproved()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeMedicineName()
        {
            return ShouldSerialize;
        }

        public string MedicineSubstanceToString()
        {
            string composition = "";
            foreach (var cmp in Composition)
            {
                composition += cmp.SubstanceName + "; ";
            }

            return composition;
        }

        [JsonIgnore]
        public string MedicineSubstances
        {
            get=>MedicineSubstanceToString();
            set
            {
                
            }
        } 
    }

}