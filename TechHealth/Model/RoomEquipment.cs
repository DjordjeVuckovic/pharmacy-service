using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class RoomEquipment
    {
        public string RoomID { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize;

        public RoomEquipment()
        {
        }

        public RoomEquipment(string roomID, string eqID, int q)
        {
            RoomID = roomID;
            EquipmentName = eqID;
            Quantity = q;
        }
    }
}
