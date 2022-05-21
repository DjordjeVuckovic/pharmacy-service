using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TechHealth.Model
{
    public class EquipmentRequest
    {
        public string RequestId { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public bool ShouldSerialize;

        public EquipmentRequest()
        {
        }

        public EquipmentRequest(string requestId, string eqID, int q)
        {
            RequestId = requestId;
            EquipmentName = eqID;
            Quantity = q;
        }
    }
}
