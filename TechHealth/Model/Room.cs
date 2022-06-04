// File:    Room.cs
// Author:  djord
// Created: Monday, March 28, 2022 8:47:46 AM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PostSharp.Patterns.Model;

namespace TechHealth.Model
{
    
    public class Room
    {

        public RoomTypes RoomTypes { get; set; }
        public string RoomId { get; set; }
        public int Floor { get; set; }
        public bool Availability { get; set; }
        public bool ShouldSerialize { get; set; }
        public Room() { }
        public Room(RoomTypes rt, string id, int flr, bool available)
        {
            RoomTypes = rt;
            RoomId = id;
            Floor = flr;
            Availability = available;
        }

        public bool ShouldSerializeroomTypes()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializefloor()
        {
            return ShouldSerialize;
        }
        public bool ShouldSerializeavailability()
        {
            return ShouldSerialize;
        }
    }
}