// File:    Medicine.cs
// Author:  djord
// Created: Monday, March 28, 2022 10:08:11 AM
// Purpose: Definition of Class Medicine

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TechHealth.Core;

namespace TechHealth.Model
{
    public class Medicine:ViewModelBase
    {
        private MedicineStatus medicineStatus;
        public string MedicineId{ get; set; }
        public List<Substance> Composition { get; set; }
        public int Quantity{ get; set; }
        public string Units{ get; set; }
        public string SideEffects{ get; set; }
        public Substance MainSubstance { get; set; }
        public double Price{ get; set; }
        public string MedicineName{ get; set; }

        public MedicineStatus MedicineStatus
        {
            get => medicineStatus;
            set
            {
                medicineStatus = value;
                OnPropertyChanged(nameof(MedicineStatus));
            }
        }

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
        
        public bool ShouldSerializePrice()
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

        public string MedicineStatusToString()
        {
            string returnValue = "";
            switch (MedicineStatus)
            {
                case MedicineStatus.Waiting:
                    returnValue = "Waiting";
                    break;
                case MedicineStatus.Approved:
                    returnValue = "Approved";
                    break;
                case MedicineStatus.Rejected:
                    returnValue = "Rejected";
                    break;
                
            }

            return returnValue;
        }
    }

}