// File:    Equipment.cs
// Author:  djord
// Created: Saturday, April 2, 2022 8:55:43 PM
// Purpose: Definition of Class Equipment

using Newtonsoft.Json;
using System;

namespace TechHealth.Model
{
   public class Equipment
   {
      public string name { get; set; }
      public string id { get; set; }
        [JsonIgnore]
      public string type { get; set; }
        [JsonIgnore]
      public int quantity { get; set; }


        public override string ToString()
        {
            return name.ToString() + ", " + id.ToString() + ", " + type.ToString() + ", " + quantity.ToString();
        }

    }
}