using Newtonsoft.Json;
using System;

namespace TechHealth.DTO
{
    public class EquipmentReallocationDTO
    {
        public string ReallocationID { get; set; }
        public string SourceRoomID { get; set; }
        public string DestinationRoomID { get; set; }
        public int AmountMoving { get; set; }
        public DateTime? ReallocationTime { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize { get; set; }
        public string EquipmentName { get; set; }

        public EquipmentReallocationDTO()
        {
        }
        public EquipmentReallocationDTO(string SourceRoomID, string DestinationRoomID, int AmountMoving, DateTime? ReallocationTime, string EquipmentName, string ReallocationID)
        {
            this.SourceRoomID = SourceRoomID;
            this.DestinationRoomID = DestinationRoomID;
            this.AmountMoving = AmountMoving;
            this.ReallocationTime = ReallocationTime;
            this.EquipmentName = EquipmentName;
            this.ReallocationID = ReallocationID;
        }

        //public bool ShouldSerializeSourceRoomID()
        //{
        //    return ShouldSerialize;
        //}
        //public bool ShouldSerializeDestinationRoomID()
        //{
        //    return ShouldSerialize;
        //}
        //public bool ShouldSerializeAmountMoving()
        //{
        //    return ShouldSerialize;
        //}
        //public bool ShouldSerializeReallocationTime()
        //{
        //    return ShouldSerialize;
        //}
        //public bool ShouldSerializeEquipmentName()
        //{
        //    return ShouldSerialize;
        //}
    }
}
