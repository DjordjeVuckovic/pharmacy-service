using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class RoomMerging
    {
        public DateTime MergeStart { get; set; }
        public DateTime MergeEnd { get; set; }
        public string RoomOne { get; set; }
        public string RoomTwo { get; set; }
        public RoomTypes RoomType { get; set; }
        public string MergeID { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize;

        public RoomMerging()
        {
        }

        public RoomMerging(DateTime start, DateTime end, string roomOne, string roomTwo, RoomTypes rt,string id)
        {
            MergeStart = start;
            MergeEnd = end;
            RoomOne = roomOne;
            RoomTwo = roomTwo;
            MergeID = id;
            RoomType = rt;
        }
    }
}
