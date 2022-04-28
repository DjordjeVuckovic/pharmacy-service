using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.DTO
{
    public class EquipmentReallocationDTO
    {
        public string ReallocationID { get; set; }
        public string SourceRoomID { get; set; }
        public string DestinationRoomID { get; set; }
        public string AmountMoving { get; set; }
        public DateTime? ReallocationTime { get; set; }
        public string EquipmentID { get; set; }

        public EquipmentReallocationDTO(string SourceRoomID, string DestinationRoomID, string AmountMoving, DateTime? ReallocationTime, string EquipmentID, string ReallocationID)
        {
            this.SourceRoomID = SourceRoomID;
            this.DestinationRoomID = DestinationRoomID;
            this.AmountMoving = AmountMoving;
            this.ReallocationTime = ReallocationTime;
            this.EquipmentID = EquipmentID;
            this.ReallocationID = ReallocationID;
        }
    }
}
