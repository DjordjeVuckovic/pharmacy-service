// File:    Room.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PostSharp.Patterns.Model;

namespace TechHealth.Model
{
    [NotifyPropertyChanged]
    public class Room
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoomTypes roomTypes { get; set; }
        public string roomId { get; set; }
        public int floor { get; set; }
        public bool availability { get; set; }
        public List<Equipment> equipment { get; set; }

        //public string Equipments
        //{
        //    get
        //    {
        //        return ToString();
        //    }
        //}

        public Room() { }
        public Room(RoomTypes rt, string id, int flr, bool available, List<Equipment> list)
        {
            roomTypes = rt;
            roomId = id;
            floor = flr;
            availability = available;
            equipment = list;
        }

        public void Add(Equipment eq)
        {
            equipment.Add(eq);
        }

        //public string ToString()
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