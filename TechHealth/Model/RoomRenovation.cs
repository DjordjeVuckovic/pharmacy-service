using Newtonsoft.Json;
using System;

namespace TechHealth.Model
{
    public class RoomRenovation
    {
        public DateTime? RenovationStart { get; set; }
        public DateTime? RenovationEnd { get; set; }
        public string RoomID { get; set; }
        public string RenovationID { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize;

        public RoomRenovation()
        {
        }

        public RoomRenovation(DateTime? start, DateTime? end, string roomid, string id)
        {
            RenovationStart = start;
            RenovationEnd = end;
            RoomID = roomid;
            RenovationID = id;
        }
    }
}
