// File:    Equipment.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:55:43 PM
// Purpose: Definition of Class Equipment

using System;


namespace TechHealth.Model
{
   public class Equipment
   {
        public string name { get; set; }
        public string id { get; set; }
        
        public EquipmentType type { get; set; }
        public int quantity { get; set; }
        public string roomID { get; set; }
        

        public Equipment() { }
        public Equipment(string name, string id, EquipmentType type, int quantity, string roomID)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            this.quantity = quantity;
            this.roomID = roomID;
        }


        //public override string ToString()
        //{
        //    return name.ToString() + ", " + id.ToString() + ", " + type.ToString() + ", " + quantity.ToString();
        //}

    }
}