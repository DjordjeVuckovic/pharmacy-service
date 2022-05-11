using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class RoomSeparation
    {
        public DateTime SeparationStart { get; set; }
        public DateTime SeparationEnd { get; set; }
        public Room RoomOne { get; set; }
        public Room RoomTwo { get; set; }
        public string SeparationID { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize;

        public RoomSeparation()
        {
        }

        public RoomSeparation(DateTime start, DateTime end, Room roomOne, Room roomTwo, string id)
        {
            SeparationStart = start;
            SeparationEnd = end;
            RoomOne = roomOne;
            RoomTwo = roomTwo;
            SeparationID = id;
        }
    }
}
