// File:    Room.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PostSharp.Patterns.Model;
using TechHealth.Conversions;

namespace TechHealth.Model
{
    [NotifyPropertyChanged]
    public class Room
    {
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public RoomTypes RoomTypes { get; set; }
        public string roomId { get; set; }
        public int floor { get; set; }
        [JsonProperty(Required = Required.Always)]
        public bool availability { get; set; }
        public List<Equipment> equipment { get; set; }

        //public string Available
        //{
        //    get
        //    {
        //        return ManagerConversions.AvailabilityToString(availability);
        //    }

        //    set
        //    {

        //    }
        //}
        public Room() {}
        public Room(RoomTypes rt, string id, int flr, bool available, List<Equipment> list)
        {
            RoomTypes = rt;
            roomId = id;
            floor = flr;
            availability = available;
            equipment = list;
        }

        //public string Equipments
        //{
        //    get
        //    {
        //        return ToString();
        //    }
        //}

        public void Add(Equipment eq)
        {
            equipment.Add(eq);
        }

        //public override string ToString()
        //{
        //    string str = "";
        //    foreach (Equipment eq in equipment)
        //    {
        //        str += eq.ToString();
        //        str += ";";
        //    }
        //    return str;
        //}
    }
}