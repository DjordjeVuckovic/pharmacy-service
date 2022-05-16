using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class EquipmentRequestRepository : GenericRepository<string, EquipmentRequest>
    {
        private static readonly EquipmentRequestRepository instance = new EquipmentRequestRepository();
        static EquipmentRequestRepository()
        {
        }

        private EquipmentRequestRepository()
        {
        }

        public static EquipmentRequestRepository Instance => instance;
        protected override string GetKey(EquipmentRequest entity)
        {
            return entity.RequestId;
        }

        protected override string GetPath()
        {
            return @"../../Json/equipmentRequest.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(EquipmentRequest entity)
        {
            entity.ShouldSerialize = true;
        }
    }
}
