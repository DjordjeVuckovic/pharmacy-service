// File:    Equipment.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:55:43 PM
// Purpose: Definition of Class Equipment

using System;


namespace TechHealth.Model
{
   public class Equipment
   {
        public string Name { get; set; }
        public string Id { get; set; }

        public EquipmentType Type { get; set; }
        public int Quantity { get; set; }


        public Equipment() { }
        public Equipment(string name, string id, EquipmentType type, int quantity)
        {
            this.Name = name;
            this.Id = id;
            this.Type = type;
            this.Quantity = quantity;
        }
    }
}