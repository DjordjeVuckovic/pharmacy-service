// File:    HealthRecord.cs
// Author:  djord
// Created: Monday, March 28, 2022 9:45:21 AM
// Purpose: Definition of Class HealthRecord

using System;

namespace TechHealth.Model
{
   public class HealthRecord
   {
      public string recordId;
      
      public System.Collections.Generic.List<Bloodtype> bloodtype;
      
      /// <summary>
      /// Property for collection of Bloodtype
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Bloodtype> Bloodtype
      {
         get
         {
            if (bloodtype == null)
               bloodtype = new System.Collections.Generic.List<Bloodtype>();
            return bloodtype;
         }
         set
         {
            RemoveAllBloodtype();
            if (value != null)
            {
               foreach (Bloodtype oBloodtype in value)
                  AddBloodtype(oBloodtype);
            }
         }
      }
      
      /// <summary>
      /// Add a new Bloodtype in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddBloodtype(Bloodtype newBloodtype)
      {
         if (newBloodtype == null)
            return;
         if (this.bloodtype == null)
            this.bloodtype = new System.Collections.Generic.List<Bloodtype>();
         if (!this.bloodtype.Contains(newBloodtype))
            this.bloodtype.Add(newBloodtype);
      }
      
      /// <summary>
      /// Remove an existing Bloodtype from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveBloodtype(Bloodtype oldBloodtype)
      {
         if (oldBloodtype == null)
            return;
         if (this.bloodtype != null)
            if (this.bloodtype.Contains(oldBloodtype))
               this.bloodtype.Remove(oldBloodtype);
      }
      
      /// <summary>
      /// Remove all instances of Bloodtype from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllBloodtype()
      {
         if (bloodtype != null)
            bloodtype.Clear();
      }
      public Gender gender;
      public System.Collections.Generic.List<Allergen> allergen;
      
      /// <summary>
      /// Property for collection of Allergen
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Allergen> Allergen
      {
         get
         {
            if (allergen == null)
               allergen = new System.Collections.Generic.List<Allergen>();
            return allergen;
         }
         set
         {
            RemoveAllAllergen();
            if (value != null)
            {
               foreach (Allergen oAllergen in value)
                  AddAllergen(oAllergen);
            }
         }
      }
      
      /// <summary>
      /// Add a new Allergen in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAllergen(Allergen newAllergen)
      {
         if (newAllergen == null)
            return;
         if (this.allergen == null)
            this.allergen = new System.Collections.Generic.List<Allergen>();
         if (!this.allergen.Contains(newAllergen))
            this.allergen.Add(newAllergen);
      }
      
      /// <summary>
      /// Remove an existing Allergen from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAllergen(Allergen oldAllergen)
      {
         if (oldAllergen == null)
            return;
         if (this.allergen != null)
            if (this.allergen.Contains(oldAllergen))
               this.allergen.Remove(oldAllergen);
      }
      
      /// <summary>
      /// Remove all instances of Allergen from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAllergen()
      {
         if (allergen != null)
            allergen.Clear();
      }
      public Patient patient;
   
   }
}