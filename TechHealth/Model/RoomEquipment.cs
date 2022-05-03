using Newtonsoft.Json;

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
