// File:    Equipment.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:55:43 PM
// Purpose: Definition of Class Equipment

using System;

namespace TechHealth.Model
{
   public class Equipment
   {
      public string name;
      public string id;
      public string type;
      public int quantity;


        public override string ToString()
        {
            return name.ToString() + ", " + id.ToString() + ", " + type.ToString() + ", " + quantity.ToString();
        }

    }
}