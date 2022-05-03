// File:    Equipment.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:55:43 PM
// Purpose: Definition of Class Equipment

namespace TechHealth.Model
{
    public class Equipment
    {
        public string name { get; set; }
        public string id { get; set; }

        public EquipmentType type { get; set; }
        public int quantity { get; set; }


        public Equipment() { }
        public Equipment(string name, string id, EquipmentType type, int quantity)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            this.quantity = quantity;
        }
    }
}