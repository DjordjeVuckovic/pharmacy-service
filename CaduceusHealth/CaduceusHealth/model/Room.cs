// File:    Room.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Room

using System;

namespace CaduceusHealth.Model
{
   public class Room
   {
      private string roomId;
      private int floor;
      private Boolean availablity;
      private string name;
      
      private RoomTypes roomTypes;
      
      public System.Collections.Generic.List<Equipment> equipment;
      
      /// <summary>
      /// Property for collection of Equipment
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Equipment> Equipment
      {
         get
         {
            if (equipment == null)
               equipment = new System.Collections.Generic.List<Equipment>();
            return equipment;
         }
         set
         {
            RemoveAllEquipment();
            if (value != null)
            {
               foreach (Equipment oEquipment in value)
                  AddEquipment(oEquipment);
            }
         }
      }
      
      /// <summary>
      /// Add a new Equipment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddEquipment(Equipment newEquipment)
      {
         if (newEquipment == null)
            return;
         if (this.equipment == null)
            this.equipment = new System.Collections.Generic.List<Equipment>();
         if (!this.equipment.Contains(newEquipment))
            this.equipment.Add(newEquipment);
      }
      
      /// <summary>
      /// Remove an existing Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveEquipment(Equipment oldEquipment)
      {
         if (oldEquipment == null)
            return;
         if (this.equipment != null)
            if (this.equipment.Contains(oldEquipment))
               this.equipment.Remove(oldEquipment);
      }
      
      /// <summary>
      /// Remove all instances of Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllEquipment()
      {
         if (equipment != null)
            equipment.Clear();
      }
   
   }
}