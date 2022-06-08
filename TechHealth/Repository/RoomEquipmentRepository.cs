using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class RoomEquipmentRepository : GenericRepository<string, RoomEquipment>, IRoomEquipmentRepository
    {
        private static readonly RoomEquipmentRepository instance = new RoomEquipmentRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomEquipmentRepository()
        {
        }

        private RoomEquipmentRepository()
        {
        }

        public static RoomEquipmentRepository Instance => instance;

        protected override string GetKey(RoomEquipment entity)
        {
            return entity.RoomID + "-" + entity.EquipmentName;
        }

        protected override string GetPath()
        {
            return @"../../Json/roomEquipment.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(RoomEquipment entity)
        {
            entity.ShouldSerialize = true;
        }
    }
}
