using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;
using TechHealth.Repository.IRepository;

namespace TechHealth.Repository
{
    public class RoomRenovationRepository : GenericRepository<string, RoomRenovation>, IRoomRenovationRepository
    {
        private static readonly RoomRenovationRepository instance = new RoomRenovationRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RoomRenovationRepository()
        {
        }

        private RoomRenovationRepository()
        {
        }

        public static RoomRenovationRepository Instance => instance;
        protected override string GetKey(RoomRenovation entity)
        {
            return entity.RenovationID;
        }

        protected override string GetPath()
        {
            return @"../../Json/roomRenovation.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(RoomRenovation entity)
        {
            entity.ShouldSerialize = true;
        }
    }
}
